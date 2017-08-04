// array.cpp : メイン プロジェクト ファイルです。

#include "stdafx.h"
#include "stdio.h"

using namespace System;

void AAA(cli::array<String^>^ a)
{
	const int n = a->Length;
	for (int i = 0; i < n; ++i) {
		String^ const s = a[i];
		Console::WriteLine(s ? s : L"<null>");
	}
}

int test()
{
	cli::array<String^>^ Name = gcnew cli::array<String^>(10);
	Name[0] = L"Alpha";
	Name[1] = L"Beta";
	AAA(Name);
	return 0;
}


int main(array<System::String ^> ^args)
{
	test();
	getchar();

    return 0;
}
