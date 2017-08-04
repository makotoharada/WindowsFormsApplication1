#include "ReportList.h"

using namespace HomeBank;

ReportItem::ReportItem()
{
	this->date = DateTime(0);
	this->name = "";
	this->kind = "";
	this->money = 0;
}

ReportItem::ReportItem(DateTime date, String^ name, String^ kind, int money)
{
	this->date = date;
	this->name = name;
	this->kind = kind;
	this->money = money;
}

String^ ReportItem::ToString()
{
		return String::Format("{0} {1} ({2}) {3}‰~", date.ToShortDateString(), name, kind, money);

}

ReportList::ReportList()
{
	this->items = gcnew List<ReportItem^>;
}

void ReportList::Clear() {
	this->items->Clear();
}
void ReportList::Add(DateTime date, String^ name, String^ kind, int money) {
	ReportItem^ item = gcnew ReportItem(date, name, kind, money);
	this->Add(item);
}
void ReportList::Add(ReportItem^ item) {
	this->items->Add(item);
}
void ReportList::Remove(DateTime date, String^ name) {

	for each (ReportItem^ item in this->items) {
		if (item->Date == date && item->Name == name) {
			Remove(item);
			break;
		}
	}
}
void ReportList::Remove(ReportItem^ item) {
	this->items->Remove(item);
}

List<ReportItem^>^ ReportList::Select(int year, int month) {

	List<ReportItem^>^ result = gcnew List<ReportItem^>;

	for each (ReportItem^ item in this->items) {
		if (item->Date.Year == year && item->Date.Month == month)
			result->Add(item);
	}

	return result;
}
