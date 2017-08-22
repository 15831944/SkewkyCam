
// PlayerDlg.h : 头文件
//

#pragma once
#include "afxcmn.h"
#include "mySliderControl.h"
#include "GradientProgressCtrl.h"
#include "ocx1.h"
#include "CWMPControls.h"
#include "CWMPSettings.h"   //设置头文件
#include "CWMPMedia.h"      //媒体头文件
// CPlayerDlg 对话框
BOOL PeekAndPump();
class CPlayerDlg : public CDialog
{
// 构造
public:
	CPlayerDlg(CWnd* pParent = NULL);	// 标准构造函数

// 对话框数据
	enum { IDD = IDD_PLAYER_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV 支持


// 实现
protected:
	HICON m_hIcon;

	// 生成的消息映射函数
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
	CWMPSettings m_setting;   //设置按钮关联
	CWMPMedia m_media;  //媒体
//	afx_msg void OnStnClickedOpen();
	DECLARE_EVENTSINK_MAP()
	void PlayStateChangeOcx1(long NewState);
	afx_msg void OnTimer(UINT_PTR nIDEvent);
	afx_msg void OnNMCustomdrawSlider2(NMHDR *pNMHDR, LRESULT *pResult);
	afx_msg void OnHScroll(UINT nSBCode, UINT nPos, CScrollBar* pScrollBar);
};
