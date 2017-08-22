
// PlayerDlg.cpp : ʵ���ļ�
//

#include "stdafx.h"
#include "Player.h"
#include "PlayerDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// ����Ӧ�ó��򡰹��ڡ��˵���� CAboutDlg �Ի���

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// �Ի�������
	enum { IDD = IDD_ABOUTBOX };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV ֧��

// ʵ��
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


// CPlayerDlg �Ի���




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


// CPlayerDlg ��Ϣ�������

BOOL CPlayerDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// ��������...���˵�����ӵ�ϵͳ�˵��С�

	// IDM_ABOUTBOX ������ϵͳ���Χ�ڡ�
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

	// ���ô˶Ի����ͼ�ꡣ��Ӧ�ó��������ڲ��ǶԻ���ʱ����ܽ��Զ�
	//  ִ�д˲���
	SetIcon(m_hIcon, TRUE);			// ���ô�ͼ��
	SetIcon(m_hIcon, FALSE);		// ����Сͼ��

	// TODO: �ڴ���Ӷ���ĳ�ʼ������
	m_Progress.ModifyStyleEx(WS_EX_STATICEDGE,0);
	m_Progress.Invalidate(false);
	// m_Progress.SendMessage(PBM_SETBKCOLOR, 0, (LPARAM)RGB(0, 200, 0));  //����ɫ
	//m_Progress.SendMessage(PBM_SETBARCOLOR, 0, (LPARAM)RGB(0, 180, 0)); //ǰ��ɫ
	/*m_Progress.SetBkColor(RGB(0, 200, 0));
	m_Progress.SetBarColor(RGB(0, 12, 0));
	m_Count=0;
	m_Progress.SetRange(0,10);*/
	m_control = static_cast <CWMPControls>(m_Media.get_controls()); 
	m_setting=m_Media.get_settings();
	m_slider1.SetPos(m_setting.get_volume());
	m_slider1.SetTicFreq(10);
	return TRUE;  // ���ǽ��������õ��ؼ������򷵻� TRUE
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

// �����Ի��������С����ť������Ҫ����Ĵ���
//  �����Ƹ�ͼ�ꡣ����ʹ���ĵ�/��ͼģ�͵� MFC Ӧ�ó���
//  �⽫�ɿ���Զ���ɡ�

void CPlayerDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // ���ڻ��Ƶ��豸������

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// ʹͼ���ڹ����������о���
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// ����ͼ��
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

//���û��϶���С������ʱϵͳ���ô˺���ȡ�ù��
//��ʾ��
HCURSOR CPlayerDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}


void CPlayerDlg::OnStnClickedRight()
{
	// TODO: �ڴ���ӿؼ�֪ͨ����������
	//AfxMessageBox(_T("�㵥���˾�̬�ı���"));
		CFileDialog dlg(TRUE, NULL, L"*.*", OFN_FILEMUSTEXIST,
			  L"Active Streaming Format(*.asf)|*.asf|"
              L"Audio Video Interleave Format(*.avi)|*.avi|"
              L"RealAudio/RealVideo(*.rm)|*.rm|"
              L"Wave Audio(*.wav)|*.wav|"
              L"MIDI File(*.mid)|*.mid|"
              L"�����ļ�(*.*)|*.*||");

       if (dlg.DoModal() == IDOK) {
              //m_ctrlMPlayer.put_stretchToFit(TRUE); // �������棬ʹ���ʺϲ��Ŵ���
              // ���� �����ڴ˽��и�����������
              m_Media.put_URL(dlg.GetPathName()); // ����ý���ļ���������
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
	// TODO: �ڴ������Ϣ�����������/�����Ĭ��ֵ
	/*CRect rc;CPoint pt;
	GetClientRect(&rc);
	ClientToScreen(&rc);
	return rc.PtInRect(pt) ? HTCAPTION : CDialog::OnNcHitTest(pt);*/
	return CDialog::OnNcHitTest(point);
}

void CPlayerDlg::OnLButtonDown(UINT nFlags, CPoint point)
{
	// TODO: �ڴ������Ϣ�����������/�����Ĭ��ֵ
	SendMessage(WM_SYSCOMMAND,0xF012,0);
	CDialog::OnLButtonDown(nFlags, point);
}

void CPlayerDlg::OnStnClickedMin()
{
	// TODO: �ڴ���ӿؼ�֪ͨ����������
	//ShowWindow(SW_SHOWMINIMIZED);     //��С��
	//OnSysCommand(SC_MINIMIZE,
	SendMessage(WM_SYSCOMMAND, SC_MINIMIZE, 0);
	//WINDOWPLACEMENT wndpl;
	//WINDOWPLACEMENT *pwndpl;
	//pwndpl = &wndpl;
	//GetWindowPlacement(pwndpl);
	//pwndpl->showCmd = SW_SHOWMINMIZED; //ʵ�ִ�����С��
	//pwndpl->showCmd = SW_MINIMIZE; //ʵ�ִ�����С��

	//SetWindowPlacement(pwndpl);
}

void CPlayerDlg::OnBnClickedOk()
{
	// TODO: �ڴ���ӿؼ�֪ͨ����������
	//OnOK();
}

void CPlayerDlg::OnBnClickedCancel()
{
	// TODO: �ڴ���ӿؼ�֪ͨ����������
	OnCancel();
}

void CPlayerDlg::OnStnClickedClose()
{
	// TODO: �ڴ���ӿؼ�֪ͨ����������
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
	// TODO: �ڴ���ӿؼ�֪ͨ����������
	m_control.play();
}

void CPlayerDlg::OnStnClickedStop()
{
	// TODO: �ڴ���ӿؼ�֪ͨ����������
	m_control.stop();
}

void CPlayerDlg::OnStnClickedPasue()
{
	// TODO: �ڴ���ӿؼ�֪ͨ����������
	m_control.pause();
}

void CPlayerDlg::OnStnClickedNext()
{
	// TODO: �ڴ���ӿؼ�֪ͨ����������
	//m_control.next();
		CFileDialog dlg(TRUE, NULL, L"*.*", OFN_FILEMUSTEXIST,
			  L"Active Streaming Format(*.asf)|*.asf|"
              L"Audio Video Interleave Format(*.avi)|*.avi|"
              L"RealAudio/RealVideo(*.rm)|*.rm|"
              L"Wave Audio(*.wav)|*.wav|"
              L"MIDI File(*.mid)|*.mid|"
              L"�����ļ�(*.*)|*.*||");

       if (dlg.DoModal() == IDOK) {
              //m_ctrlMPlayer.put_stretchToFit(TRUE); // �������棬ʹ���ʺϲ��Ŵ���
              // ���� �����ڴ˽��и�����������
              m_Media.put_URL(dlg.GetPathName()); // ����ý���ļ���������
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
//	// TODO: �ڴ���ӿؼ�֪ͨ����������

//}
BEGIN_EVENTSINK_MAP(CPlayerDlg, CDialog)
	ON_EVENT(CPlayerDlg, IDC_OCX1, 5101, CPlayerDlg::PlayStateChangeOcx1, VTS_I4)
END_EVENTSINK_MAP()

void CPlayerDlg::PlayStateChangeOcx1(long NewState)
{
	// TODO: �ڴ˴������Ϣ����������
	 if (NewState==3)                //����״̬ʱ, ������ʱ��  
        SetTimer(1,1000,NULL);    
     else if (NewState==1)             //ֹͣʱ, �رն�ʱ��, ��������0  
     {  
        m_Progress.SetPos(0);  
         KillTimer(1);  
     }  
     else  
        KillTimer(1); 
}

void CPlayerDlg::OnTimer(UINT_PTR nIDEvent)
{
	// TODO: �ڴ������Ϣ�����������/�����Ĭ��ֵ
 if (nIDEvent != 1)    
         return;  
     m_Progress.SetPos(m_Progress.GetPos()+1); 
	CDialog::OnTimer(nIDEvent);
}

void CPlayerDlg::OnNMCustomdrawSlider2(NMHDR *pNMHDR, LRESULT *pResult)
{
	LPNMCUSTOMDRAW pNMCD = reinterpret_cast<LPNMCUSTOMDRAW>(pNMHDR);
	// TODO: �ڴ���ӿؼ�֪ͨ����������
	/*UpdateData();
	m_setting.put_volume(m_slider1.GetPos());
	UpdateData(FALSE);*/
	*pResult = 0;
}

void CPlayerDlg::OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar)
{
	// TODO: �ڴ������Ϣ�����������/�����Ĭ��ֵ
UpdateData();
	m_setting.put_volume(m_slider1.GetPos());
	UpdateData(FALSE);
	CDialog::OnHScroll(nSBCode, nPos, pScrollBar);
}
