
// PlayerDlg.h : ͷ�ļ�
//

#pragma once
#include "afxcmn.h"
#include "mySliderControl.h"
#include "GradientProgressCtrl.h"
#include "ocx1.h"
#include "CWMPControls.h"
#include "CWMPSettings.h"   //����ͷ�ļ�
#include "CWMPMedia.h"      //ý��ͷ�ļ�
// CPlayerDlg �Ի���
BOOL PeekAndPump();
class CPlayerDlg : public CDialog
{
// ����
public:
	CPlayerDlg(CWnd* pParent = NULL);	// ��׼���캯��

// �Ի�������
	enum { IDD = IDD_PLAYER_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV ֧��


// ʵ��
protected:
	HICON m_hIcon;

	// ���ɵ���Ϣӳ�亯��
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnStnClickedRight();
	afx_msg LRESULT OnNcHitTest(CPoint point);
	afx_msg void OnLButtonDown(UINT nFlags, CPoint point);
	CmySliderControl m_slider1;
	afx_msg void OnStnClickedMin();
	afx_msg void OnBnClickedOk();
	afx_msg void OnBnClickedCancel();
	afx_msg void OnStnClickedClose();
	CProgressCtrl m_Progress;
	int m_Count;
	COcx1 m_Media;
	CWMPControls m_control; 
	afx_msg void OnStnClickedPlay();
	afx_msg void OnStnClickedStop();
	afx_msg void OnStnClickedPasue();
	afx_msg void OnStnClickedNext();
	CWMPSettings m_setting;   //���ð�ť����
	CWMPMedia m_media;  //ý��
//	afx_msg void OnStnClickedOpen();
	DECLARE_EVENTSINK_MAP()
	void PlayStateChangeOcx1(long NewState);
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	afx_msg void OnNMCustomdrawSlider2(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar);
};
