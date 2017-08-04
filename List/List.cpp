// List.cpp : メイン プロジェクト ファイルです。

#include "stdafx.h"
#include "stdio.h"
#include <cliext/vector>

using namespace System;
using namespace System::Collections::Generic;
//using namespace System::Collections;

void AAA(List<String^>^ a)
{
	const int n = a->Count;
	for (int i = 0; i < n; ++i) {
		String^ const s = a[i];
		Console::WriteLine(s ? s : L"<null>");
	}
}

int test()
{
	List<String^>^ Name = gcnew List<String^>();
	Name->Add(L"Alpha");
	Name->Add(L"Beta");
	AAA(Name);
	return 0;
}

int main(array<System::String ^> ^args)
{
	test();
	getchar();

	return 0;
}
