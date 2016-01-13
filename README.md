# test-shop
MVC приложение для управления товарами в магазине: для их создания, добавления, редактирования и удаления.
Приложение разрабатывалось в Visual Studio 2015.

Для запуска приложения необходимо:
1) скачать архив
2) для скачки необходимых пакетов в Visual Studio зайдите во вкладку Tools -> NuGet Package Manager -> Package Manager Settings и поставьте галочку напротив пунктов Allow NuGet to download missing packeges и Automatickally check for missing packages during build in Visual Studio
3) Build Solution
4) Запускайте. Приложение должно работать.

Для просмотра списка всех товаров нажмите кнопку "Show goods". Для добавления нового товара в таблицу нажмите по ссылке "Add new good". Для удаления и редактирования товаров нажмите по ссылкам "Delete" и "Edit" соответственно напротив соответсвующего товара (после нажатия на кнопку "Show goods".

Для корректной работы unit-тестов в файле GoodServiceTest.cs необходимо в участке кода 
public string ConnString
{
  get
  {
      return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=d:\\!!!TEST\\ShopApp\\ShopApp\\App_Data\\ShopDB.mdb";
  }
}
изменить путь, по которому располагается БД, на актуальный для Вас. В проекте она располагается в папке App_Data.
