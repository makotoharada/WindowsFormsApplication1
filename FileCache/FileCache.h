#pragma once
#include "windows.h"
 
#define FILECACHE_OUTOF_RANGE (-1)  //インデックス範囲外のエラーコード 
 
// ファイルをメモリにキャッシュ 
class CFileCache 
{ 
private: 
    char* m_pData;  //メモリ上のバッファポインター 
    int m_nLength;  //メモリ上のデータサイズ(バイト数) 
public: 
    CFileCache(void);  //コンストラクター 
    ~CFileCache(void); //デストラクター 
private: 
    BOOL AllocData(int size); //メモリ確保、メンバー変数設定 
    void ClearData();         //メモリ解放、メンバー変数初期化 
public: 
    BOOL Load(LPCWSTR filePath);  //ファイル読み込み 
    char operator[](int ndx);     //インデックスでのアクセス 
    int GetLength() { return m_nLength; } //データサイズの取得(バイト数) 
};