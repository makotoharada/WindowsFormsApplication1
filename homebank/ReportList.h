#pragma once

namespace HomeBank {

	using namespace System;
	using namespace System::Collections::Generic;

	ref class ReportItem
	{
	private:
		DateTime date;
		String^ name;
		String^ kind;
		int money;
	public:
		property DateTime Date {
			DateTime get() { return this->date; }
			void set(DateTime value) { this->date = value; }
		}
		property String^ Name{
			String^ get() { return this->name; }
			void set(String^ value) { this->name = value; };
		}
		property String^ Kind{
			String^ get() { return this->kind; }
			void set(String^ value) { this->kind = value; };
		}
		property int Money{
			int  get() { return this->money; }
			void set(int value) { this->money = value; };
		}
	public:
		ReportItem();
		ReportItem(DateTime date, String^ name, String^ kind, int money);
		virtual String^ ToString() override;
	};

	ref class ReportList
	{
	private: 
		List<ReportItem^>^ items;
	public:
		ReportList();
		void Clear();
		void Add(DateTime date, String^ name, String^ kind, int money);
		void Add(ReportItem^ item);
		void Remove(DateTime date, String^ name);
		void Remove(ReportItem^ item);
		List<ReportItem^>^ Select(int year, int month);
		property List<ReportItem^>^ Items {
			List<ReportItem^>^ get() { return this->items; }
		}
	};


}
