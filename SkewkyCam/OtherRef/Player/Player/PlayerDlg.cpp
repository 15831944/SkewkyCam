
// PlayerDlg.cpp : 实现文件
//

#include "stdafx.h"
#include "Player.h"
#include "PlayerDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// 用于应用程序“关于”菜单项的 CAboutDlg 对话框

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// 对话框数据
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV 支持

// 实现
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
END_MESSAGE_MAP()


// CPlayerDlg 对话框




CPlayerDlg::CPlayerDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CPlayerDlg::IDD, pParent)
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CPlayerDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_SLIDER2, m_slider1);
	DDX_Control(pDX, IDC_PROGRESS1, m_Progress);
	DDX_Control(pDX, IDC_OCX1, m_Media);
}

BEGIN_MESSAGE_MAP(CPlayerDlg, CDialog)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
	ON_STN_CLICKED(IDC_RIGHT, &CPlayerDlg::OnStnClickedRight)
	ON_WM_NCHITTEST()
	ON_WM_LBUTTONDOWN()
	ON_STN_CLICKED(IDC_MIN, &CPlayerDlg::OnStnClickedMin)
	ON_BN_CLICKED(IDOK, &CPlayerDlg::OnBnClickedOk)
	ON_BN_CLICKED(IDCANCEL, &CPlayerDlg::OnBnClickedCancel)
	ON_STN_CLICKED(IDC_CLOSE, &CPlayerDlg::OnStnClickedClose)
	ON_STN_CLICKED(IDC_PLAY, &CPlayerDlg::OnStnClickedPlay)
	ON_STN_CLICKED(IDC_STOP, &CPlayerDlg::OnStnClickedStop)
	ON_STN_CLICKED(IDC_PASUE, &CPlayerDlg::OnStnClickedPasue)
	ON_STN_CLICKED(IDC_NEXT, &CPlayerDlg::OnStnClickedNext)
//	ON_STN_CLICKED(IDC_OPEN, &CPlayerDlg::OnStnClickedOpen)
ON_WM_TIMER()
ON_NOTIFY(NM_CUSTOMDRAW, IDC_SLIDER2, &CPlayerDlg::OnNMCustomdrawSlider2)
ON_WM_HSCROLL()
END_MESSAGE_MAP()


// CPlayerDlg 消息处理程序

BOOL CPlayerDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// 将“关于...”菜单项添加到系统菜单中。

	// IDM_ABOUTBOX 必须在系统命令范围内。
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		BOOL bNameValid;
		CString strAboutMenu;
		bNameValid = strAboutMenu.LoadString(IDS_ABOUTBOX);
		ASSERT(bNameValid);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// 设置此对话框的图标。当应用程序主窗口不是对话框时，框架将自动
	//  执行此操作
	SetIcon(m_hIcon, TRUE);			// 设置大图标
	SetIcon(m_hIcon, FALSE);		// 设置小图标

	// TODO: 在此添加额外的初始化代码
	m_Progress.ModifyStyleEx(WS_EX_STATICEDGE,0);
	m_Progress.Invalidate(false);
	// m_Progress.SendMessage(PBM_SETBKCOLOR, 0, (LPARAM)RGB(0, 200, 0));  //背景色
	//m_Progress.SendMessage(PBM_SETBARCOLOR, 0, (LPARAM)RGB(0, 180, 0)); //前景色
	/*m_Progress.SetBkColor(RGB(0, 200, 0));
	m_Progress.SetBarColor(RGB(0, 12, 0));
	m_Count=0;
	m_Progress.SetRange(0,10);*/
	m_control = static_cast <CWMPControls>(m_Media.get_controls()); 
	m_setting=m_Media.get_settings();
	m_slider1.SetPos(m_setting.get_volume());
	m_slider1.SetTicFreq(10);
	return TRUE;  // 除非将焦点设置到控件，否则返回 TRUE
}

void CPlayerDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// 如果向对话框添加最小化按钮，则需要下面的代码
//  来绘制该图标。对于使用文档/视图模型的 MFC 应用程序，
//  这将由框架自动完成。

void CPlayerDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // 用于绘制的设备上下文

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// 使图标在工作区矩形中居中
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// 绘制图标
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

//当用户拖动最小化窗口时系统调用此函数取得光标
//显示。
HCURSOR CPlayerDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


void CPlayerDlg::OnStnClickedRight()
{
	// TODO: 在此添加控件通知处理程序代码
	//AfxMessageBox(_T("你单击了静态文本！"));
		CFileDialog dlg(TRUE, NULL, L"*.*", OFN_FILEMUSTEXIST,
			  L"Active Streaming Format(*.asf)|*.asf|"
              L"Audio Video Interleave Format(*.avi)|*.avi|"
              L"RealAudio/RealVideo(*.rm)|*.rm|"
              L"Wave Audio(*.wav)|*.wav|"
              L"MIDI File(*.mid)|*.mid|"
              L"所有文件(*.*)|*.*||");

       if (dlg.DoModal() == IDOK) {
              //m_ctrlMPlayer.put_stretchToFit(TRUE); // 伸缩画面，使其适合播放窗口
              // …… 可以在此进行各种其他设置
              m_Media.put_URL(dlg.GetPathName()); // 传递媒体文件到播放器
			  KillTimer(1);
       }
	   else 
		   return ;
	   m_media=static_cast<CWMPMedia>(m_Media.newMedia(dlg.GetPathName()));
	   m_Progress.SetRange(0,(int)m_media.get_duration());
	   m_Progress.SetPos(0);	
}

LRESULT CPlayerDlg::OnNcHitTest(CPoint point)
{
	// TODO: 在此添加消息处理程序代码和/或调用默认值
	/*CRect rc;CPoint pt;
	GetClientRect(&rc);
	ClientToScreen(&rc);
	return rc.PtInRect(pt) ? HTCAPTION : CDialog::OnNcHitTest(pt);*/
	return CDialog::OnNcHitTest(point);
}

void CPlayerDlg::OnLButtonDown(UINT nFlags, CPoint point)
{
	// TODO: 在此添加消息处理程序代码和/或调用默认值
	SendMessage(WM_SYSCOMMAND,0xF012,0);
	CDialog::OnLButtonDown(nFlags, point);
}

void CPlayerDlg::OnStnClickedMin()
{
	// TODO: 在此添加控件通知处理程序代码
	//ShowWindow(SW_SHOWMINIMIZED);     //最小化
	//OnSysCommand(SC_MINIMIZE,
	SendMessage(WM_SYSCOMMAND, SC_MINIMIZE, 0);
	//WINDOWPLACEMENT wndpl;
	//WINDOWPLACEMENT *pwndpl;
	//pwndpl = &wndpl;
	//GetWindowPlacement(pwndpl);
	//pwndpl->showCmd = SW_SHOWMINMIZED; //实现窗口最小化
	//pwndpl->showCmd = SW_MINIMIZE; //实现窗口最小化

	//SetWindowPlacement(pwndpl);
}

void CPlayerDlg::OnBnClickedOk()
{
	// TODO: 在此添加控件通知处理程序代码
	//OnOK();
}

void CPlayerDlg::OnBnClickedCancel()
{
	// TODO: 在此添加控件通知处理程序代码
	OnCancel();
}

void CPlayerDlg::OnStnClickedClose()
{
	// TODO: 在此添加控件通知处理程序代码
	OnBnClickedCancel();
}
BOOL PeekAndPump()
{
	static MSG msg;
	while(::PeekMessage(&msg,NULL,0,0,PM_NOREMOVE))
	{
		if(!AfxGetApp()->PumpMessage()){
			::PostQuitMessage(0);
			return FALSE;
		}
	}
	return TRUE;
}
void CPlayerDlg::OnStnClickedPlay()
{
	// TODO: 在此添加控件通知处理程序代码
	m_control.play();
}

void CPlayerDlg::OnStnClickedStop()
{
	// TODO: 在此添加控件通知处理程序代码
	m_control.stop();
}

void CPlayerDlg::OnStnClickedPasue()
{
	// TODO: 在此添加控件通知处理程序代码
	m_control.pause();
}

void CPlayerDlg::OnStnClickedNext()
{
	// TODO: 在此添加控件通知处理程序代码
	//m_control.next();
		CFileDialog dlg(TRUE, NULL, L"*.*", OFN_FILEMUSTEXIST,
			  L"Active Streaming Format(*.asf)|*.asf|"
              L"Audio Video Interleave Format(*.avi)|*.avi|"
              L"RealAudio/RealVideo(*.rm)|*.rm|"
              L"Wave Audio(*.wav)|*.wav|"
              L"MIDI File(*.mid)|*.mid|"
              L"所有文件(*.*)|*.*||");

       if (dlg.DoModal() == IDOK) {
              //m_ctrlMPlayer.put_stretchToFit(TRUE); // 伸缩画面，使其适合播放窗口
              // …… 可以在此进行各种其他设置
              m_Media.put_URL(dlg.GetPathName()); // 传递媒体文件到播放器
			  KillTimer(1);
       }
	   else
		   return ;
	    m_media=static_cast<CWMPMedia>(m_Media.newMedia(dlg.GetPathName()));
	   m_Progress.SetRange(0,(int)m_media.get_duration());
	   m_Progress.SetPos(0);	  

}

//void CPlayerDlg::OnStnClickedOpen()
//{
//	// TODO: 在此添加控件通知处理程序代码

//}
BEGIN_EVENTSINK_MAP(CPlayerDlg, CDialog)
	ON_EVENT(CPlayerDlg, IDC_OCX1, 5101, CPlayerDlg::PlayStateChangeOcx1, VTS_I4)
END_EVENTSINK_MAP()

void CPlayerDlg::PlayStateChangeOcx1(long NewState)
{
	// TODO: 在此处添加消息处理程序代码
	 if (NewState==3)                //播放状态时, 开启定时器  
        SetTimer(1,1000,NULL);    
     else if (NewState==1)             //停止时, 关闭定时器, 进度条回0  
     {  
        m_Progress.SetPos(0);  
         KillTimer(1);  
     }  
     else  
        KillTimer(1); 
}

void CPlayerDlg::OnTimer(UINT_PTR nIDEvent)
{
	// TODO: 在此添加消息处理程序代码和/或调用默认值
 if (nIDEvent != 1)    
         return;  
     m_Progress.SetPos(m_Progress.GetPos()+1); 
	CDialog::OnTimer(nIDEvent);
}

void CPlayerDlg::OnNMCustomdrawSlider2(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMCUSTOMDRAW pNMCD = reinterpret_cast<LPNMCUSTOMDRAW>(pNMHDR);
	// TODO: 在此添加控件通知处理程序代码
	/*UpdateData();
	m_setting.put_volume(m_slider1.GetPos());
	UpdateData(FALSE);*/
	*pResult = 0;
}

void CPlayerDlg::OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar)
{
	// TODO: 在此添加消息处理程序代码和/或调用默认值
UpdateData();
	m_setting.put_volume(m_slider1.GetPos());
	UpdateData(FALSE);
	CDialog::OnHScroll(nSBCode, nPos, pScrollBar);
}
