#include "H.h"
#include "pch.h"
#include <stdio.h>
#include <emmintrin.h>

void BlendC(unsigned char* tab, unsigned char val)
{

	__m128i* l = (__m128i*)tab;					// za�adowanie tablicy 16 pikseli do rejestru xmm l
	__m128i* r = &_mm_set1_epi8(val);			// wype�nienie  rejestru xmm r 16 warto�ciami val(wspolczynnik zmiany jasnosci)
	_mm_store_si128(l, _mm_subs_epu8(*l, *r));	// zsumowanie dw�ch rejestr�w xmm (r+l), a nast�pnie zapisanie ich w xmm l
	return;
}