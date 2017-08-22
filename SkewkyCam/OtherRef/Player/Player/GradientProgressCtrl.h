#pragma once 

class CGradientProgressCtrl : public CProgressCtrl
{
public:
	CGradientProgressCtrl()					;	// 构造
	virtual ~CGradientProgressCtrl()			;	// 析构

	int  SetPos(int nPos)					;	// 设置位置
	int  SetStep(int nStep)					;	// 设置步进值
	void SetRange(int nLower, int nUpper)			;	// 设置范围
	int  SetText(const char * pText, BOOL bRepaint = TRUE)	;	// 设置显示文字

public:
	void ShowPercent(BOOL bShowPercent = TRUE)	{ m_bShowPercent = bShowPercent; }	    // 显示百分比
	void ShowText(BOOL bShowText = TRUE)		{ m_bShowText = bShowText; }    // 显示文字

public:
	COLORREF GetTextColor(void)	{ return m_clrText	; }		// 取得字体颜色
	COLORREF GetBkColor(void)		{ return m_clrBkGround	; }	// 取得背景颜色
	COLORREF GetStartColor(void)	{ return m_clrStart	; }		// 取得开始颜色
	COLORREF GetEndColor(void)		{ return m_clrEnd		; }	// 取得结束颜色
	void SetStartColor(COLORREF color)	{ m_clrStart	= color ; }		// 设置字体颜色
	void SetEndColor(COLORREF color)	{ m_clrEnd	= color ; }		// 设置背景颜色
	void SetTextColor(COLORREF color)	{ m_clrText	= color ; }		// 设置开始颜色
	void SetBkColor(COLORREF color)						        // 设置结束颜色
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
	// 变量定义
	int			m_nLower			;	// 最小值
	int			m_nUpper			;	// 最大值
	int			m_nStep			        ;	// 步进值
	int			m_nCurPos			;	// 当前值
	COLORREF m_clrStart		        ;	// 起始颜色
	COLORREF	m_clrEnd		;	// 结束颜色
	COLORREF	m_clrBkGround		;	// 背景颜色
	COLORREF	m_clrText		;	// 文本颜色
	BOOL		m_bShowPercent		;	// 显示百分比
	BOOL		m_bShowText		;	// 显示文字

	char		m_Text[32]		;	// 文字：如显示拷贝速度
	char		m_Percent[4]		;	// 文字：百分比

	CBrush		m_BKGroundBrush		;	// 背景刷子
	CBrush		m_TempBrush		;        // 临时刷子

private:
	// 内嵌类
	class CMemDC : public CDC			// 内存设备环境
	{
	public:
		CMemDC(CDC* pDC):CDC()
		{
			ASSERT(pDC != NULL);

			m_pDC = pDC;
			m_pOldBitmap = NULL;
			m_bMemDC = !pDC->IsPrinting();
			// 图形设备还是打印机设备
			if (m_bMemDC)
			{
				pDC->GetClipBox(&m_rect);
				CreateCompatibleDC(pDC);
				m_bitmap.CreateCompatibleBitmap(pDC, m_rect.Width(), m_rect.Height());
				m_pOldBitmap = SelectObject(&m_bitmap);
				SetWindowOrg(m_rect.left, m_rect.top);
			}
			else	//为相关的现有设备准备打印
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