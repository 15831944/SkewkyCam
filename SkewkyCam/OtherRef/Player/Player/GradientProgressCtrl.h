#pragma once 

class CGradientProgressCtrl : public CProgressCtrl
{
public:
	CGradientProgressCtrl()					;	// ����
	virtual ~CGradientProgressCtrl()			;	// ����

	int  SetPos(int nPos)					;	// ����λ��
	int  SetStep(int nStep)					;	// ���ò���ֵ
	void SetRange(int nLower, int nUpper)			;	// ���÷�Χ
	int  SetText(const char * pText, BOOL bRepaint = TRUE)	;	// ������ʾ����

public:
	void ShowPercent(BOOL bShowPercent = TRUE)	{ m_bShowPercent = bShowPercent; }	    // ��ʾ�ٷֱ�
	void ShowText(BOOL bShowText = TRUE)		{ m_bShowText = bShowText; }    // ��ʾ����

public:
	COLORREF GetTextColor(void)	{ return m_clrText	; }		// ȡ��������ɫ
	COLORREF GetBkColor(void)		{ return m_clrBkGround	; }	// ȡ�ñ�����ɫ
	COLORREF GetStartColor(void)	{ return m_clrStart	; }		// ȡ�ÿ�ʼ��ɫ
	COLORREF GetEndColor(void)		{ return m_clrEnd		; }	// ȡ�ý�����ɫ
	void SetStartColor(COLORREF color)	{ m_clrStart	= color ; }		// ����������ɫ
	void SetEndColor(COLORREF color)	{ m_clrEnd	= color ; }		// ���ñ�����ɫ
	void SetTextColor(COLORREF color)	{ m_clrText	= color ; }		// ���ÿ�ʼ��ɫ
	void SetBkColor(COLORREF color)						        // ���ý�����ɫ
	{
		m_clrBkGround = color ;
		m_BKGroundBrush.DeleteObject();
		m_BKGroundBrush.CreateSolidBrush(m_clrBkGround);
	}

private:
	void Draw(CPaintDC* pDC, const RECT& rectClient, const int& nMaxWidth);
	afx_msg void OnPaint();
	DECLARE_MESSAGE_MAP()

private:
	// ��������
	int			m_nLower			;	// ��Сֵ
	int			m_nUpper			;	// ���ֵ
	int			m_nStep			        ;	// ����ֵ
	int			m_nCurPos			;	// ��ǰֵ
	COLORREF m_clrStart		        ;	// ��ʼ��ɫ
	COLORREF	m_clrEnd		;	// ������ɫ
	COLORREF	m_clrBkGround		;	// ������ɫ
	COLORREF	m_clrText		;	// �ı���ɫ
	BOOL		m_bShowPercent		;	// ��ʾ�ٷֱ�
	BOOL		m_bShowText		;	// ��ʾ����

	char		m_Text[32]		;	// ���֣�����ʾ�����ٶ�
	char		m_Percent[4]		;	// ���֣��ٷֱ�

	CBrush		m_BKGroundBrush		;	// ����ˢ��
	CBrush		m_TempBrush		;        // ��ʱˢ��

private:
	// ��Ƕ��
	class CMemDC : public CDC			// �ڴ��豸����
	{
	public:
		CMemDC(CDC* pDC):CDC()
		{
			ASSERT(pDC != NULL);

			m_pDC = pDC;
			m_pOldBitmap = NULL;
			m_bMemDC = !pDC->IsPrinting();
			// ͼ���豸���Ǵ�ӡ���豸
			if (m_bMemDC)
			{
				pDC->GetClipBox(&m_rect);
				CreateCompatibleDC(pDC);
				m_bitmap.CreateCompatibleBitmap(pDC, m_rect.Width(), m_rect.Height());
				m_pOldBitmap = SelectObject(&m_bitmap);
				SetWindowOrg(m_rect.left, m_rect.top);
			}
			else	//Ϊ��ص������豸׼����ӡ
			{
				m_bPrinting = pDC->m_bPrinting;
				m_hDC = pDC->m_hDC;
				m_hAttribDC = pDC->m_hAttribDC;
			}
		}
		virtual ~CMemDC()
		{
			if (m_bMemDC)
			{
				m_pDC->BitBlt(m_rect.left, 
					     m_rect.top, 
					     m_rect.Width(),
					     m_rect.Height(), 
					     this, 
					     m_rect.left, 
					     m_rect.top,
					     SRCCOPY
					     );
				SelectObject(m_pOldBitmap);
			}
			else
			{
				m_hDC = m_hAttribDC = NULL;
			}
		}
		CMemDC* operator->()
		{
			return this;
		}
		operator CMemDC*()
		{
			return this;
		}
	private:
		CBitmap m_bitmap;
		CBitmap* m_pOldBitmap;  		//
		CDC* m_pDC; 			        //
		CRect m_rect;   			//
		BOOL m_bMemDC;  			//
	};

};