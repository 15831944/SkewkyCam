// GradientProgressCtrl.cpp : ʵ���ļ�
//

#include "stdafx.h"
#include "Player.h"
#include "GradientProgressCtrl.h"


// CGradientProgressCtrl

CGradientProgressCtrl::CGradientProgressCtrl()
{
	// �ؼ���ʼ��
	m_nLower	        = 0		;
	m_nUpper	        = 100	        ;
	m_nCurPos	        = 0		;
	m_nStep                 = 1		;

	// ��ʼ����ʾ��ɫ
	m_clrStart	= COLORREF(RGB(255, 255, 0))		;
	m_clrEnd		= COLORREF(RGB(0, 0, 255))	;
	m_clrBkGround	= ::GetSysColor(COLOR_3DFACE)	        ;
	m_clrText		= COLORREF(RGB(255, 255, 255))	;

	// ��ʾ�ٷֱȣ�����
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
// CGradientProgressCtrl ��Ϣ�������

void CGradientProgressCtrl::SetRange(int nLower, int nUpper)
{
	// ���ý������ķ�Χ
	m_nLower	= nLower ;
	m_nUpper	= nUpper ;
	m_nCurPos	= nLower ;

	CProgressCtrl::SetRange(nLower, nUpper);
	CProgressCtrl::SetPos(nLower);
}

int CGradientProgressCtrl::SetStep(int nStep)
{
	// ���ò���ֵ
	m_nStep = nStep;
	return (CProgressCtrl::SetStep(nStep));
}

int CGradientProgressCtrl::SetPos(int nPos)
{
	// ���ý�����λ��
	m_nCurPos = nPos;
	return (CProgressCtrl::SetPos(nPos));
}

int CGradientProgressCtrl::SetText(const char * pText, BOOL bRepaint)
{
	// ��ʾ������
	strcpy(m_Text, pText);
	if (bRepaint && m_bShowText)
	{
		Invalidate(TRUE);
	}

	return 0;
}

void CGradientProgressCtrl::OnPaint()
{
	CPaintDC dc(this); // �豸����

	// TODO: �ػ�������
	RECT rectClient;
	GetClientRect(&rectClient);

	if (m_nCurPos <= m_nLower || m_nCurPos > m_nUpper)
	{
		// ���ڷ�Χ֮��ֱ���Ա���ɫ���
		dc.FillRect(&rectClient, &m_BKGroundBrush);
		return;
	}

	// ���ƽ���������
	float maxWidth((float) m_nCurPos /(float) m_nUpper*(float) rectClient.right);
	Draw(&dc, rectClient, (int) maxWidth);

	// ������ʾ
	dc.SetTextColor(m_clrText);
	dc.SetBkMode(TRANSPARENT);
	HGDIOBJ hOldFont = ::SelectObject(dc.m_hDC, ::GetStockObject(DEFAULT_GUI_FONT));
	if (m_bShowPercent)
	{
		// ��ʾ�������ٷֱ�
		sprintf(m_Percent, "%d%% ",(int) (100 * (float) m_nCurPos / m_nUpper));
		CString m_Percent1(m_Percent);
		dc.DrawText(m_Percent1, &rectClient, DT_VCENTER | DT_CENTER | DT_SINGLELINE);
	}
	if (m_bShowText)
	{
		// ��ʾ����������
		rectClient.left = (rectClient.left + rectClient.right) / 2;
		CString m_Text1(m_Text);
		dc.DrawText(m_Text1, &rectClient, DT_VCENTER | DT_CENTER | DT_SINGLELINE);
	}
	::SelectObject(dc.m_hDC, hOldFont);

	// ��Ҫ���� CProgressCtrl::OnPaint()
}

void CGradientProgressCtrl::Draw(CPaintDC* pDC, const RECT& rectClient, const int& nMaxWidth)
{
	RECT rectFill;			//��ʾ����
	float fStep;			//ÿһ���ķ���
	CMemDC memDC(pDC);	

	int r, g, b;
	float rStep, gStep, bStep;
	//�õ���ͬ��ɫ�������������ɫ֮�������ֵ
	r = (GetRValue(m_clrEnd) - GetRValue(m_clrStart));
	g = (GetGValue(m_clrEnd) - GetGValue(m_clrStart));
	b = (GetBValue(m_clrEnd) - GetBValue(m_clrStart));
	//ʹ��������ʾ������ ����������ɫ��ֵ
	int nSteps = max(abs(r), max(abs(g), abs(b)));
	//ȷ��ÿһ��ɫ�����ľ�������
	fStep = (float) rectClient.right / (float) nSteps;
	//����ÿһ��ɫ���Ĳ���
	rStep = r / (float) nSteps;
	gStep = g / (float) nSteps;
	bStep = b / (float) nSteps;

	r = GetRValue(m_clrStart);
	g = GetGValue(m_clrStart);
	b = GetBValue(m_clrStart);
	//������ɫ����Ľ�����
	for (int iOnBand = 0; iOnBand < nSteps; iOnBand++)
	{
		::SetRect(&rectFill, (int) (iOnBand * fStep), 0,// ��������������Ͻ�x,y�����½�x,y
			(int) ((iOnBand + 1) * fStep), rectClient.bottom + 1);

		VERIFY(m_TempBrush.CreateSolidBrush(RGB(r + rStep * iOnBand,
										g + gStep * iOnBand,
										b + bStep * iOnBand)));
		memDC.FillRect(&rectFill, &m_TempBrush);
		VERIFY(m_TempBrush.DeleteObject());
		//�ڽ�������֮ǰ��ʹ�ñ���ɫ�����µĵĿͻ�����
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


