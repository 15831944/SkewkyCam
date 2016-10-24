using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Collections.Generic;
using System.Text;

namespace Com.Skewky.Vlc
{
    public class VlcPlayer
    {
        private IntPtr _libvlcInstance;
        private IntPtr _libvlcMediaPlayer;
        private double _duration;
        private string _playPath;
        public bool IsPlaying { get; private set; }

        public VlcPlayer(string pluginPath)
        {
            IsPlaying = false;
            string pluginArg = "--plugin-path=" + pluginPath;
            string[] arguments = { "-I", "dummy", "--ignore-config", "--no-video-title", "--rtsp-tcp", pluginArg };
            _libvlcInstance = LibVlcApi.libvlc_new(arguments);

            _libvlcMediaPlayer = LibVlcApi.libvlc_media_player_new(_libvlcInstance);
        }
        ~VlcPlayer()
        {
            Stop();
        }
        public void Copy(VlcPlayer vlcPlayer)
        {
            _libvlcInstance = vlcPlayer._libvlcInstance;
            _libvlcMediaPlayer = vlcPlayer._libvlcMediaPlayer;
            _duration = vlcPlayer._duration;
            _playPath = vlcPlayer._playPath;

        }
        public void SetPlayInfo(PlayInfo pInfo)
        {
            if (null == pInfo)
                return;
            if (_playPath != pInfo.FilePath)
                PlayFile(pInfo.FilePath);
            SetPlayTime(pInfo.CurTime);
            SetRate(pInfo.DPlayingSpeed);
            SetVolume(pInfo.DValume);
            if(pInfo.PlayStatus == VlcSta.LibvlcPlaying)
            {
                Play();
                SetPlayTime(pInfo.CurTime);
            }
            else if (pInfo.PlayStatus == VlcSta.LibvlcPaused)
            {
                Pause();
            }
            else if (pInfo.PlayStatus == VlcSta.LibvlcStopped)
            {
                Stop();
            }
        }
        public PlayInfo GetPlayInfo()
        {
            PlayInfo pInfo = new PlayInfo();
            pInfo.FilePath = _playPath;
            pInfo.CurTime = GetPlayTime();
            pInfo.PlayStatus = GetPlayerStatus();
            pInfo.DPlayingSpeed = GetRate();
            pInfo.DValume = GetVolume();
            return pInfo;
        }
        public void SetRenderWindow(int wndHandle)
        {
            if (_libvlcInstance != IntPtr.Zero && wndHandle != 0)
            {
                LibVlcApi.libvlc_media_player_set_hwnd(_libvlcMediaPlayer, wndHandle);
            }
        }

        public void PlayFile(string filePath)
        {
            IntPtr libvlcMedia = LibVlcApi.libvlc_media_new_path(_libvlcInstance, filePath);
            if (libvlcMedia != IntPtr.Zero)
            {
                LibVlcApi.libvlc_media_parse(libvlcMedia);
                _duration = LibVlcApi.libvlc_media_get_duration(libvlcMedia);

                LibVlcApi.libvlc_media_player_set_media(_libvlcMediaPlayer, libvlcMedia);
                LibVlcApi.libvlc_media_release(libvlcMedia);

                LibVlcApi.libvlc_media_player_play(_libvlcMediaPlayer);
                _playPath = filePath;
                IsPlaying = true;
            }
        }
        public void PrepareFile(string filePath)
        {
            IntPtr libvlcMedia = LibVlcApi.libvlc_media_new_path(_libvlcInstance, filePath);
            if (libvlcMedia != IntPtr.Zero)
            {
                LibVlcApi.libvlc_media_parse(libvlcMedia);
                _duration = LibVlcApi.libvlc_media_get_duration(libvlcMedia);

                LibVlcApi.libvlc_media_player_set_media(_libvlcMediaPlayer, libvlcMedia);
                LibVlcApi.libvlc_media_release(libvlcMedia);
                _playPath = filePath;
                //LibVlcApi.libvlc_media_player_play(_libvlcMediaPlayer);
            }
        }
        public void Pause()
        {
            if (_libvlcMediaPlayer != IntPtr.Zero)
            {
                LibVlcApi.libvlc_media_player_pause(_libvlcMediaPlayer);
                IsPlaying = false;
            }
        }
        public void TooglePlay()
        {
            if (IsPlaying)
                Pause();
            else
                Play();
        }
        public void Play()
        {
            if (_libvlcMediaPlayer != IntPtr.Zero)
            {
                LibVlcApi.libvlc_media_player_play(_libvlcMediaPlayer);
                IsPlaying = true;
            }
        }
        public void Stop()
        {
            if (_libvlcMediaPlayer != IntPtr.Zero)
            {
                LibVlcApi.libvlc_media_player_stop(_libvlcMediaPlayer);
                IsPlaying = true;
            }
        }

        public double GetPlayTime()
        {
            return LibVlcApi.libvlc_media_player_get_time(_libvlcMediaPlayer) / 1000.0;
        }

        public void SetPlayTime(double seekTime)
        {
            LibVlcApi.libvlc_media_player_set_time(_libvlcMediaPlayer, (Int64)(seekTime * 1000));
        }

        public int GetVolume()
        {
            return LibVlcApi.libvlc_audio_get_volume(_libvlcMediaPlayer);
        }

        public void SetVolume(int volume)
        {
            LibVlcApi.libvlc_audio_set_volume(_libvlcMediaPlayer, volume);
        }

        public void SetFullScreen(bool istrue)
        {
            LibVlcApi.libvlc_set_fullscreen(_libvlcMediaPlayer, istrue ? 1 : 0);
        }
        public void SetRate(double rate)
        {
            if (_libvlcMediaPlayer != IntPtr.Zero)
            {
                LibVlcApi.libvlc_media_player_set_rate(_libvlcMediaPlayer, (float)rate);
            }
        }
        public double GetRate()
        {
            double rate = 1;
            if (_libvlcMediaPlayer != IntPtr.Zero)
            {
                rate = (float)LibVlcApi.libvlc_media_player_get_rate(_libvlcMediaPlayer);
            }
            return rate;
        }
        public double Duration()
        {
            return _duration;
        }

        public string Version()
        {
            return LibVlcApi.libvlc_get_version();
        }
        public bool IsPlayEnded()
        {
            VlcSta sta = (VlcSta)LibVlcApi.libvlc_media_player_get_state(_libvlcMediaPlayer);
            return VlcSta.LibvlcEnded == sta;
        }
        public VlcSta GetPlayerStatus()
        {
            VlcSta sta = (VlcSta)LibVlcApi.libvlc_media_player_get_state(_libvlcMediaPlayer);
            return sta;
        }
    }

    internal static class LibVlcApi
    {
        internal struct PointerToArrayOfPointerHelper
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
            public IntPtr[] Pointers;
        }

        public static IntPtr libvlc_new(string[] arguments)
        {
            PointerToArrayOfPointerHelper argv = new PointerToArrayOfPointerHelper();
            argv.Pointers = new IntPtr[11];

            for (int i = 0; i < arguments.Length; i++)
            {
                argv.Pointers[i] = Marshal.StringToHGlobalAnsi(arguments[i]);
            }

            IntPtr argvPtr = IntPtr.Zero;
            try
            {
                int size = Marshal.SizeOf(typeof(PointerToArrayOfPointerHelper));
                argvPtr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(argv, argvPtr, false);

                return libvlc_new(arguments.Length, argvPtr);
            }
            finally
            {
                for (int i = 0; i < arguments.Length + 1; i++)
                {
                    if (argv.Pointers[i] != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(argv.Pointers[i]);
                    }
                }
                if (argvPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(argvPtr);
                }
            }
        }

        public static IntPtr libvlc_media_new_path(IntPtr libvlcInstance, string path)
        {
            IntPtr pMrl = IntPtr.Zero;
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(path);
                pMrl = Marshal.AllocHGlobal(bytes.Length + 1);
                Marshal.Copy(bytes, 0, pMrl, bytes.Length);
                Marshal.WriteByte(pMrl, bytes.Length, 0);
                return libvlc_media_new_path(libvlcInstance, pMrl);
            }
            finally
            {
                if (pMrl != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pMrl);
                }
            }
        }

        public static IntPtr libvlc_media_new_location(IntPtr libvlcInstance, string path)
        {
            IntPtr pMrl = IntPtr.Zero;
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(path);
                pMrl = Marshal.AllocHGlobal(bytes.Length + 1);
                Marshal.Copy(bytes, 0, pMrl, bytes.Length);
                Marshal.WriteByte(pMrl, bytes.Length, 0);
                return libvlc_media_new_path(libvlcInstance, pMrl);
            }
            finally
            {
                if (pMrl != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pMrl);
                }
            }
        }

        // ----------------------------------------------------------------------------------------
        // 以下是libvlc.dll导出函数

        // 创建一个libvlc实例，它是引用计数的
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        private static extern IntPtr libvlc_new(int argc, IntPtr argv);

        // 释放libvlc实例
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void libvlc_release(IntPtr libvlcInstance);

        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern String libvlc_get_version();

        // 从视频来源(例如Url)构建一个libvlc_meida
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        private static extern IntPtr libvlc_media_new_location(IntPtr libvlcInstance, IntPtr path);

        // 从本地文件路径构建一个libvlc_media
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        private static extern IntPtr libvlc_media_new_path(IntPtr libvlcInstance, IntPtr path);

        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void libvlc_media_release(IntPtr libvlcMediaInst);

        // 创建libvlc_media_player(播放核心)
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr libvlc_media_player_new(IntPtr libvlcInstance);

        // 将视频(libvlcMedia)绑定到播放器上
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void libvlc_media_player_set_media(IntPtr libvlcMediaPlayer, IntPtr libvlcMedia);

        // 设置图像输出的窗口
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void libvlc_media_player_set_hwnd(IntPtr libvlcMediaplayer, Int32 drawable);

        // 设置播放
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void libvlc_media_player_play(IntPtr libvlcMediaplayer);

        // 设置暂停
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void libvlc_media_player_pause(IntPtr libvlcMediaplayer);

        // 设置停止
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void libvlc_media_player_stop(IntPtr libvlcMediaplayer);

        // 解析视频资源的媒体信息(如时长等)
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void libvlc_media_parse(IntPtr libvlcMedia);

        // 返回视频的时长(必须先调用libvlc_media_parse之后，该函数才会生效)
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern Int64 libvlc_media_get_duration(IntPtr libvlcMedia);

        // 当前播放的时间
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern Int64 libvlc_media_player_get_time(IntPtr libvlcMediaplayer);

        // 设置播放位置(拖动)
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void libvlc_media_player_set_time(IntPtr libvlcMediaplayer, Int64 time);

        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void libvlc_media_player_release(IntPtr libvlcMediaplayer);

        // 获取和设置音量
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int libvlc_audio_get_volume(IntPtr libvlcMediaPlayer);

        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void libvlc_audio_set_volume(IntPtr libvlcMediaPlayer, int volume);

        // 设置全屏
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void libvlc_set_fullscreen(IntPtr libvlcMediaPlayer, int isFullScreen);

        // 设置播放速度
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void libvlc_media_player_set_rate(IntPtr libvlcMediaPlayer, float rate);

        // 获取播放速度
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern float libvlc_media_player_get_rate(IntPtr libvlcMediaPlayer);

        //获取播放状态
        [DllImport("libvlc", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
        [SuppressUnmanagedCodeSecurity]
        public static extern int libvlc_media_player_get_state(IntPtr libvlcMediaPlayer);
    
    }
}
