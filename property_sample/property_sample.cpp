// property_sample.cpp : メイン プロジェクト ファイルです。

#include "stdafx.h"

using namespace System;

ref class A  {
	int value;
public:
	property int Value {
		int get() {
			System::Console::WriteLine("A:: Value::get()");
			return this->value;
		}
		void set (int value) {
			System::Console::WriteLine("A:: Value::set()");
			this->value = value;
		}

	}

	property int Lines[int]{
		int get(int ndx) {
			System::Console::WriteLine("A:: Lines::get({0})", ndx);
			return 0;
		}
		void set(int ndx, int value) {
			System::Console::WriteLine("A:: Lines::set({0})", ndx);
		}
	}

};

int main(array<System::String ^> ^args)
{

	A obj;
	obj.Value = 5;
    Console::WriteLine("A.obj = {0}\n", obj.Value);

	obj.Lines[3] = 5;
    Console::WriteLine("obj.Lines = {0}\n", obj.Lines[3]);
    return 0;
}
