   M S B A M L   `   `   `  ����N  JChefDeliveryService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FermerGoodsApp.PagesFermerGoodsApp.Pages  5      &     FermerGoodsApp.Pages.ClientsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:FermerGoodsApp.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5           MaterialDesignBody#���   5	      $��Regular"�5
   	   $��14(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper N� 
Background# �  5   	     MaterialDesignFont N� 
FontFamily# �  5   	    N� Title$ Пользователи��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $��40 �6   �� 5      $��50 �6   .+�5   
   � $��0��6   $��Stretch=�5      .+�5      �� -   5         ��Name$ 
TBoxSearch��5   "   $	��275��6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$B <Введите Имя пользователя или ФИО��68   5      �� 5!      -   5         ��Name$ ComboUserType��5!   #   $	��275��6   $��14(�6:   $��3q�6H   $6 0Выберите тип пользователя��5"      	 �� DisplayMemberPath$	 Title��5#      6/   �� 5&      -   5        $ 	ComboSort��5'      $	��275��5&      $ Сортировать��6#   $��10 0 0 0q�5(   H   .@�5)      �� .��5*      �� 
 �� Orientation$
 
Horizontal=�6!   .+�5+      �� $��ФИО��6$   '  !MaterialDesignThemes.Wpf.PackIcon  5,         Kind$ SortAscending=�62   $��5 0 0 0q�6G   5-      5.      �� 5/      .��50      �� $
 
Horizontal=�6!   .+�51      �� $��ФИО��6$     52      $ SortDescending=�62   $��5 0 0 0q�6H   53      54      �� 55      .��56      �� $
 
Horizontal=�6!   .+�57      �� $��Группа��6$     58      $ SortAscending=�62   $��5 0 0 0q�6G   59      5:      �� 5;      .��5<      �� $
 
Horizontal=�6!   .+�5=      �� $��Группа��6$     5>      $ SortDescending=�62   $��5 0 0 0q�6H   5?      5@      5A      5C      &   System.Windows.Controls.DataGrid  5E   
   -   5          Name$ DataGridData��5E      $��1��6)      AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�5I      ��5H      ��    Columns 5K      4  .System.Windows.Controls.DataGridTemplateColumn  5L      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6)      Header$ Фото��65      CellTemplate 5M      �� 5N      .R�5O      �� ��6$   ��  �� Path$ GetPhoto�5P      5R      0  *System.Windows.Controls.DataGridTextColumn  5S      $% Имя пользователя��6B   $ * 6\   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6%   �� *
UserName+6\     5T      $ Фамилия��6B   $ * 6S    6%   �� *
LastName+6S     5U      $ Имя��6C   $ * 6P    6%   �� *	FirstName+6P     5V      $ Отчество��6D   $ * 6V    6%   �� *
MiddleName+6V     5W      $ E-mail��6?   $ * 6O    6%   �� *Email+6O     5X      $ Роль��6D   $ * 6R    6%   �� *
Role.Title+6R     5Y      $ Телефон��6?   $ * 6P    6%   �� *Phone+6P     5^      $
 auto 6)    5_      �� 5`      .R�5a      ��  ��Name$ BtnEdit��6@   -   5        $��Center=�5a   %     MaterialDesignFlatButton#��[ 6R    � ToolTip$ Изменить��5b   Z   $��40��6n   ��6!   0
  *MaterialDesignThemes.Wpf.PackIconExtension
   
  Kind$
 Edit=� 
  Size$ 24X�6z   5c      5e        5f      $
 auto 6)    5g      �� 5h      .R�5i      �� $ 	BtnDelete��6@   -   5        $��Center=�5i   %   #��[ 6T   $ Удалить��5j   \   $��40��6o   ��6!   
  $ Delete=�$ 24X�6{   5k      5m      5r      �� 5s   
   -   5        $ BtnAdd��5s      $��3��6!   $	��100��6.   $��Right=�6:   $��3 0 10 0q�6V   $��Добавить��5t      6$   �� 5v   
   -	   5         ��Name$ TextBlockCount��5v   !   $��3��6   $	��300��69   $
��Left=�6F   5x      5y      