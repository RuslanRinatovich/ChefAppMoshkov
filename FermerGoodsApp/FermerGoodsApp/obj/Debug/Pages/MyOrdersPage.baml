   M S B A M L   `   `   `  ����N  JChefDeliveryService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FermerGoodsApp.PagesFermerGoodsApp.Pages  5      '    !FermerGoodsApp.Pages.MyOrdersPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:FermerGoodsApp.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N� Title$  Мои заявки��5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��50 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridOrders��5       $��0��6   $��Stretch=�68   $��Stretch=�6V      AutoGenerateColumns .   �� AlternationCount$ 1��5   /      SelectionMode$ Single=�6D      CanUserAddRows .     
IsReadOnly .    RowStyle 5      �� 5      	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  6   .�5      �� 
 �� Property
 � �� �� Value 63   �� *Color+5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6<      Width5  /System.Windows.Controls.DataGridLengthConverter$ 40 6J   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+6J     5      $ Создан��6m   $ 3* 6    6%   �� *	DateStart+ �� StringFormat$ d�� �� ConverterCulture$ ru-RU��6     5      $ Статус��6D   $ 3* 6V    6%   �� *
StatusName+6V     5      $ Цена��6n   $ 3* 6~    6%   �� *
TotalPrice+$ c��$ ru-RU��6~   4  .System.Windows.Controls.DataGridTemplateColumn  5"      $
 auto 6)   $ Посмотреть��66      CellTemplate 5#      �� 5$      .R�5%      ��  ��Name$ BtnLook��6%   -   5        $��0q�5%   y   ��66   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$	 Eye=�6y   5&      5(        5)      $
 auto 6)   $ Отменить��66    5*      �� 5+      .R�5,      �� $ 	BtnCancel��6%   -   5        $��60��5,   h   ��68     $ Delete=�6s   5-      5/      54      �� 55   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��Center=�6V   .+�56      �� $ 
Horizontal=�6   .+�57      �� -   5         ��Name$ cmbSearchType��57      
�������$��Stretch=�6F   $��Center=�6b   $	��200��6�    �� SelectedIndex$ 0��6�   $��10,0,0,0q�6�   .@�58      �� $��Поиск по ID��6#   �� 59      $$��Поиск по клиенту��6#   �� 5:      $��Поиск по дате ��6#   5;      �� 5<      -   5         ��Name$ 
tbSearchID��5<      $
�� 100��6.   $��1q�6<   
�������6P   �� 5=      -   5        $ 	btnSearch��5=      $��60��6,   
�������
���   �.��5?      '	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind$ Search=�6.   ���#FF0000$��Center=�6Q   5B      �� 5C      -   5        $ btnClearSearch��5C      $��60��61   
�������
���   �.��5E      	  $ Cancel=�6.   ���#FF0000$��Center=�6Q   5H      5J      5K      5P      5Q      