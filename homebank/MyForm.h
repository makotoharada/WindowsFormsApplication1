#pragma once
#include "ReportList.h"

namespace homebank {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace System::Diagnostics;
	using namespace HomeBank;

	/// <summary>
	/// Summary for MyForm
	/// </summary>
	public ref class MyForm : public System::Windows::Forms::Form
	{
	private:
		ReportList ^ report;

	public:
		MyForm(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
			this->report = gcnew ReportList();
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::MenuStrip^  menuStrip1;
	private: System::Windows::Forms::DateTimePicker^  dateCalendar;

	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Label^  label3;
	private: System::Windows::Forms::Label^  label4;
	private: System::Windows::Forms::TextBox^  textName;
	private: System::Windows::Forms::TextBox^  textMoney;
	private: System::Windows::Forms::TextBox^  textSum;





	private: System::Windows::Forms::ComboBox^  comboKind;

	private: System::Windows::Forms::Button^  buttonAdd;
	private: System::Windows::Forms::Button^  buttonDelete;
	private: System::Windows::Forms::ListBox^  listMoney;
	private: System::Windows::Forms::ToolStripMenuItem^  ファイルFToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  開くOToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  上書き保存SToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  名前を付けて保存AToolStripMenuItem;
	private: System::Windows::Forms::ToolStripMenuItem^  閉じるCToolStripMenuItem;



	protected:

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->menuStrip1 = (gcnew System::Windows::Forms::MenuStrip());
			this->ファイルFToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->開くOToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->上書き保存SToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->名前を付けて保存AToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->閉じるCToolStripMenuItem = (gcnew System::Windows::Forms::ToolStripMenuItem());
			this->dateCalendar = (gcnew System::Windows::Forms::DateTimePicker());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->textName = (gcnew System::Windows::Forms::TextBox());
			this->textMoney = (gcnew System::Windows::Forms::TextBox());
			this->textSum = (gcnew System::Windows::Forms::TextBox());
			this->comboKind = (gcnew System::Windows::Forms::ComboBox());
			this->buttonAdd = (gcnew System::Windows::Forms::Button());
			this->buttonDelete = (gcnew System::Windows::Forms::Button());
			this->listMoney = (gcnew System::Windows::Forms::ListBox());
			this->menuStrip1->SuspendLayout();
			this->SuspendLayout();
			// 
			// menuStrip1
			// 
			this->menuStrip1->ImageScalingSize = System::Drawing::Size(20, 20);
			this->menuStrip1->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(1) { this->ファイルFToolStripMenuItem });
			this->menuStrip1->Location = System::Drawing::Point(0, 0);
			this->menuStrip1->Name = L"menuStrip1";
			this->menuStrip1->Size = System::Drawing::Size(538, 28);
			this->menuStrip1->TabIndex = 0;
			this->menuStrip1->Text = L"menuStrip1";
			// 
			// ファイルFToolStripMenuItem
			// 
			this->ファイルFToolStripMenuItem->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(4) {
				this->開くOToolStripMenuItem,
					this->上書き保存SToolStripMenuItem, this->名前を付けて保存AToolStripMenuItem, this->閉じるCToolStripMenuItem
			});
			this->ファイルFToolStripMenuItem->Name = L"ファイルFToolStripMenuItem";
			this->ファイルFToolStripMenuItem->Size = System::Drawing::Size(79, 24);
			this->ファイルFToolStripMenuItem->Text = L"ファイル(&F)";
			// 
			// 開くOToolStripMenuItem
			// 
			this->開くOToolStripMenuItem->Name = L"開くOToolStripMenuItem";
			this->開くOToolStripMenuItem->Size = System::Drawing::Size(213, 26);
			this->開くOToolStripMenuItem->Text = L"開く(&O)";
			// 
			// 上書き保存SToolStripMenuItem
			// 
			this->上書き保存SToolStripMenuItem->Name = L"上書き保存SToolStripMenuItem";
			this->上書き保存SToolStripMenuItem->Size = System::Drawing::Size(213, 26);
			this->上書き保存SToolStripMenuItem->Text = L"上書き保存(&S)";
			// 
			// 名前を付けて保存AToolStripMenuItem
			// 
			this->名前を付けて保存AToolStripMenuItem->Name = L"名前を付けて保存AToolStripMenuItem";
			this->名前を付けて保存AToolStripMenuItem->Size = System::Drawing::Size(213, 26);
			this->名前を付けて保存AToolStripMenuItem->Text = L"名前を付けて保存(&A)";
			// 
			// 閉じるCToolStripMenuItem
			// 
			this->閉じるCToolStripMenuItem->Name = L"閉じるCToolStripMenuItem";
			this->閉じるCToolStripMenuItem->Size = System::Drawing::Size(213, 26);
			this->閉じるCToolStripMenuItem->Text = L"閉じる(&C)";
			// 
			// dateCalendar
			// 
			this->dateCalendar->Location = System::Drawing::Point(12, 48);
			this->dateCalendar->Name = L"dateCalendar";
			this->dateCalendar->Size = System::Drawing::Size(204, 22);
			this->dateCalendar->TabIndex = 1;
			this->dateCalendar->ValueChanged += gcnew System::EventHandler(this, &MyForm::dateCalendar_ValueChanged);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(9, 92);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(37, 15);
			this->label1->TabIndex = 2;
			this->label1->Text = L"品名";
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(9, 123);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(37, 15);
			this->label2->TabIndex = 3;
			this->label2->Text = L"分類";
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(9, 155);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(37, 15);
			this->label3->TabIndex = 4;
			this->label3->Text = L"金額";
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Location = System::Drawing::Point(232, 51);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(37, 15);
			this->label4->TabIndex = 5;
			this->label4->Text = L"合計";
			// 
			// textName
			// 
			this->textName->Location = System::Drawing::Point(59, 84);
			this->textName->Name = L"textName";
			this->textName->Size = System::Drawing::Size(157, 22);
			this->textName->TabIndex = 6;
			// 
			// textMoney
			// 
			this->textMoney->Location = System::Drawing::Point(59, 155);
			this->textMoney->Name = L"textMoney";
			this->textMoney->Size = System::Drawing::Size(157, 22);
			this->textMoney->TabIndex = 8;
			// 
			// textSum
			// 
			this->textSum->Location = System::Drawing::Point(281, 48);
			this->textSum->Name = L"textSum";
			this->textSum->Size = System::Drawing::Size(167, 22);
			this->textSum->TabIndex = 9;
			// 
			// comboKind
			// 
			this->comboKind->FormattingEnabled = true;
			this->comboKind->Items->AddRange(gcnew cli::array< System::Object^  >(4) { L"食費", L"本代", L"遊び", L"交通費" });
			this->comboKind->Location = System::Drawing::Point(59, 120);
			this->comboKind->Name = L"comboKind";
			this->comboKind->Size = System::Drawing::Size(157, 23);
			this->comboKind->TabIndex = 11;
			// 
			// buttonAdd
			// 
			this->buttonAdd->Location = System::Drawing::Point(59, 196);
			this->buttonAdd->Name = L"buttonAdd";
			this->buttonAdd->Size = System::Drawing::Size(75, 23);
			this->buttonAdd->TabIndex = 12;
			this->buttonAdd->Text = L"追加";
			this->buttonAdd->UseVisualStyleBackColor = true;
			this->buttonAdd->Click += gcnew System::EventHandler(this, &MyForm::buttonAdd_Click);
			// 
			// buttonDelete
			// 
			this->buttonDelete->Location = System::Drawing::Point(141, 195);
			this->buttonDelete->Name = L"buttonDelete";
			this->buttonDelete->Size = System::Drawing::Size(75, 23);
			this->buttonDelete->TabIndex = 13;
			this->buttonDelete->Text = L"削除";
			this->buttonDelete->UseVisualStyleBackColor = true;
			this->buttonDelete->Click += gcnew System::EventHandler(this, &MyForm::buttonDelete_Click);
			// 
			// listMoney
			// 
			this->listMoney->FormattingEnabled = true;
			this->listMoney->ItemHeight = 15;
			this->listMoney->Location = System::Drawing::Point(235, 84);
			this->listMoney->Name = L"listMoney";
			this->listMoney->Size = System::Drawing::Size(291, 154);
			this->listMoney->TabIndex = 14;
			this->listMoney->SelectedIndexChanged += gcnew System::EventHandler(this, &MyForm::listBox1_SelectedIndexChanged);
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(8, 15);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(538, 253);
			this->Controls->Add(this->listMoney);
			this->Controls->Add(this->buttonDelete);
			this->Controls->Add(this->buttonAdd);
			this->Controls->Add(this->comboKind);
			this->Controls->Add(this->textSum);
			this->Controls->Add(this->textMoney);
			this->Controls->Add(this->textName);
			this->Controls->Add(this->label4);
			this->Controls->Add(this->label3);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->dateCalendar);
			this->Controls->Add(this->menuStrip1);
			this->MainMenuStrip = this->menuStrip1;
			this->Name = L"MyForm";
			this->Text = L"HomeBank";
			this->menuStrip1->ResumeLayout(false);
			this->menuStrip1->PerformLayout();
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void listBox1_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
	}
	private: System::Void buttonAdd_Click(System::Object^  sender, System::EventArgs^  e) {
		Debug::WriteLine("追加ボタンをクリックしました");

		String^ name = textName->Text;
		String^ kind = comboKind->Text;
		int money = int::Parse(textMoney->Text);
		DateTime date = dateCalendar->Value;

		this->report->Add(date, name, kind, money);
		UpdateListMoney();

		//String^ out;
		//out = String::Format("{0},{1},{2}円", name, kind, money);
		//out = date + "" + out;
		//listMoney->Items->Add(out);
		//Debug::WriteLine(out);

	}

	private: System::Void buttonDelete_Click(System::Object^  sender, System::EventArgs^  e) {

		int index = listMoney->SelectedIndex;

		if (index == -1)
			return;

		ReportItem^ item = (ReportItem^)listMoney->SelectedItem;

		if (MessageBox::Show("本当に削除しますか？", "HomeBank", MessageBoxButtons::OKCancel)
			!= System::Windows::Forms::DialogResult::OK)
			return;

		this->report->Remove(item);
		UpdateListMoney();
	}

	private: System::Void dateCalendar_ValueChanged(System::Object^  sender, System::EventArgs^  e) {
		UpdateListMoney();
	}

	private: void UpdateListMoney(void)
	{
		listMoney->Items->Clear();
		int sum;

		DateTime date = dateCalendar->Value;

		for each (ReportItem^ item in this->report->Select(date.Year, date.Month)) {
			listMoney->Items->Add(item);
			sum += item->Money;
		}

		//if(item->Date.Month == dateCalendar->Value.Month && 
		//	item->Date.Day == dateCalendar->Value.Day )
		//	listMoney->Items->Add(item);

		for each (ReportItem^ item in this->report->Select(date.Year, date.Month)) {
			listMoney->Items->Add(item);
		}

		// calculate_sum();

		textSum->Text = sum.ToString();
	}


};
}
