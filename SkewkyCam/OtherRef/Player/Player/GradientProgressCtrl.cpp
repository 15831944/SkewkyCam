// GradientProgressCtrl.cpp : 实现文件
//

#include "stdafx.h"
#include "Player.h"
#include "GradientProgressCtrl.h"


// CGradientProgressCtrl

CGradientProgressCtrl::CGradientProgressCtrl()
{
	// 控件初始化
	m_nLower	        = 0		;
	m_nUpper	        = 100	        ;
	m_nCurPos	        = 0		;
	m_nStep                 = 1		;

	// 初始化显示颜色
	m_clrStart	= COLORREF(RGB(255, 255, 0))		;
	m_clrEnd		= COLORREF(RGB(0, 0, 255))	;
	m_clrBkGround	= ::GetSysColor(COLOR_3DFACE)	        ;
	m_clrText		= COLORREF(RGB(255, 255, 255))	;

	// 显示百分比，文字
	m_bShowPercent	= TRUE ;
	m_bShowText	= TRUE ;

	m_BKGroundBrush.CreateSolidBrush(m_clrBkGround)	;
	memset(m_Text, 0, 32);
}

CGradientProgressCtrl::~CGradientProgressCtrl()
{
	m_BKGroundBrush.DeleteObject();
}

BEGIN_MESSAGE_MAP(CGradientProgressCtrl, CProgressCtrl)
	ON_WM_PAINT()
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CGradientProgressCtrl 消息处理程序

void CGradientProgressCtrl::SetRange(int nLower, int nUpper)
{
	// 设置进度条的范围
	m_nLower	= nLower ;
	m_nUpper	= nUpper ;
	m_nCurPos	= nLower ;

	CProgressCtrl::SetRange(nLower, nUpper);
	CProgressCtrl::SetPos(nLower);
}

int CGradientProgressCtrl::SetStep(int nStep)
{
	// 设置步进值
	m_nStep = nStep;
	return (CProgressCtrl::SetStep(nStep));
}

int CGradientProgressCtrl::SetPos(int nPos)
{
	// 设置进度条位置
	m_nCurPos = nPos;
	return (CProgressCtrl::SetPos(nPos));
}

int CGradientProgressCtrl::SetText(const char * pText, BOOL bRepaint)
{
	// 显示的文字
	strcpy(m_Text, pText);
	if (bRepaint && m_bShowText)
	{
		Invalidate(TRUE);
	}

	return 0;
}

void CGradientProgressCtrl::OnPaint()
{
	CPaintDC dc(this); // 设备环境

	// TODO: 重画进度条
	RECT rectClient;
	GetClientRect(&rectClient);

	if (m_nCurPos <= m_nLower || m_nCurPos > m_nUpper)
	{
		// 不在范围之内直接以背景色填充
		dc.FillRect(&rectClient, &m_BKGroundBrush);
		return;
	}

	// 绘制进度条本身
	float maxWidth((float) m_nCurPos /(float) m_nUpper*(float) rectClient.right);
	Draw(&dc, rectClient, (int) maxWidth);

	// 文字显示
	dc.SetTextColor(m_clrText);
	dc.SetBkMode(TRANSPARENT);
	HGDIOBJ hOldFont = ::SelectObject(dc.m_hDC, ::GetStockObject(DEFAULT_GUI_FONT));
	if (m_bShowPercent)
	{
		// 显示进程条百分比
		sprintf(m_Percent, "%d%% ",(int) (100 * (float) m_nCurPos / m_nUpper));
		CString m_Percent1(m_Percent);
		dc.DrawText(m_Percent1, &rectClient, DT_VCENTER | DT_CENTER | DT_SINGLELINE);
	}
	if (m_bShowText)
	{
		// 显示进程条文字
		rectClient.left = (rectClient.left + rectClient.right) / 2;
		CString m_Text1(m_Text);
		dc.DrawText(m_Text1, &rectClient, DT_VCENTER | DT_CENTER | DT_SINGLELINE);
	}
	::SelectObject(dc.m_hDC, hOldFont);

	// 不要调用 CProgressCtrl::OnPaint()
}

void CGradientProgressCtrl::Draw(CPaintDC* pDC, const RECT& rectClient, const int& nMaxWidth)
{
	RECT rectFill;			//显示区域
	float fStep;			//每一步的幅宽
	CMemDC memDC(pDC);	

	int r, g, b;
	float rStep, gStep, bStep;
	//得到不同颜色并相减，返回颜色之间的最大差值
	r = (GetRValue(m_clrEnd) - GetRValue(m_clrStart));
	g = (GetGValue(m_clrEnd) - GetGValue(m_clrStart));
	b = (GetBValue(m_clrEnd) - GetBValue(m_clrStart));
	//使进程条显示的总数 等于最大的颜色差值
	int nSteps = max(abs(r), max(abs(g), abs(b)));
	//确定每一颜色填充多大的矩形区域
	fStep = (float) rectClient.right / (float) nSteps;
	//设置每一颜色填充的步数
	rStep = r / (float) nSteps;
	gStep = g / (float) nSteps;
	bStep = b / (float) nSteps;

	r = GetRValue(m_clrStart);
	g = GetGValue(m_clrStart);
	b = GetBValue(m_clrStart);
	//绘制颜色渐变的进程条
	for (int iOnBand = 0; iOnBand < nSteps; iOnBand++)
	{
		::SetRect(&rectFill, (int) (iOnBand * fStep), 0,// 填充矩形区域的左上角x,y和右下角x,y
			(int) ((iOnBand + 1) * fStep), rectClient.bottom + 1);

		VERIFY(m_TempBrush.CreateSolidBrush(RGB(r + rStep * iOnBand,
										g + gStep * iOnBand,
										b + bStep * iOnBand)));
		memDC.FillRect(&rectFill, &m_TempBrush);
		VERIFY(m_TempBrush.DeleteObject());
		//在结束绘制之前，使用背景色填充乘下的的客户区域
		if (rectFill.right > nMaxWidth)
		{
			::SetRect(&rectFill, rectFill.right, 0, rectClient.right,
				rectClient.bottom);
			VERIFY(m_TempBrush.CreateSolidBrush(m_clrBkGround));
			memDC.FillRect(&rectFill, &m_TempBrush);
			VERIFY(m_TempBrush.DeleteObject());
			return;
		}
	}
}


