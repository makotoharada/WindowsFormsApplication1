// vector.cpp : コンソール アプリケーションのエントリ ポイントを定義します。
//

#include "stdafx.h"
#include <iostream>
#include <vector>
using namespace std;

void show_size(vector<int> v)
{
	cout << "Size = " << v.size() << endl;
}

void show_contents(vector<int> v)
{
	int i;

	cout << "Current contents: \n";
	for (i = 0; i < v.size(); i++)
		cout << v[i] << " ";
	cout << endl;
}

int main()
{
	// vector: コンテナの一種
	// - 動的配列をサポートしている。
	//   - 必要に応じてサイズを増やすことのできる配列のこと。
	// 

	vector<int> v;	// 長さが0のvectorを作成する。
	int i;

	show_size(v);

	for (i = 0; i < 10; i++)
		v.push_back(i);

	show_contents(v);
	show_size(v);

	for (i = 0; i < 10; i++)
		v.push_back(i + 10);

	show_contents(v);
	show_size(v);

	v.insert(v.begin(), 10, 9);

	show_contents(v);
	show_size(v);

	v.erase(v.begin(), v.begin() + 5);
	show_contents(v);
	show_size(v);

    return 0;
}

