   M S B A M L   `   `   `  ����N  JChefDeliveryService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FermerGoodsApp.PagesFermerGoodsApp.Pages  5      +    %FermerGoodsApp.Pages.SellerOrdersPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:FermerGoodsApp.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N� Title$  Мои заявки��5
      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��50 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGridOrders��5       $��0��6   $��Stretch=�68   $��Stretch=�6V      AutoGenerateColumns .   �� AlternationCount$ 1��5   /      SelectionMode$ Single=�6D      CanUserAddRows .     
IsReadOnly .    RowStyle 5      �� 5      	 �� 
TargetType)  #System.Windows.Controls.DataGridRow"	  6   .�5      �� 
 �� Property
 � �� �� Value 63   �� *Status.Color+5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6<   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+6<     5      $ Номер заказа��6A    6%   �� *	OrderId+6A     5      $ Создан��6m    6%   �� *	DateStart+ �� StringFormat$ d�� �� ConverterCulture$ ru-RU��6m     5      $ Клиент��6G    6%   �� *Client.GetFio+6G     5      $ Статус��6E    6%   �� *Status.Name+6E     5!      $ 
ИТОГО��6n    6%   �� *
TotalPrice+$ c��$ ru-RU��6n   4  .System.Windows.Controls.DataGridTemplateColumn  5#         Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6)   $ Создана��66      CellTemplate 5$      �� 5%      .R�5&      ��  ��Name$ 	BtnCreate��6%   -   5        $��40��5&   o   $��0q�6z   $��0q�6�   ��68   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ CursorDefault=�6�   5'      5)        5*      $
 auto 6)   $ Принять��66    5+      �� 5,      .R�5-      �� $ BtnGet��6%   -   5        $��40��5-   h   $��0q�6s   $��0q�6�   ��65     $ 	CheckBold=�6�   5.      50        51      $
 auto 6)   $ В пути��66    52      �� 53      .R�54      �� $ BtnRoad��6%   -   5        $��40��54   d   $��0q�6o   ��66     $
 Road=�6|   55      57        58      $
 auto 6)   $ Доставлено��66    59      �� 5:      .R�5;      �� $ BtnDone��6%   -   5        $��0q�5;   m   $��40��6y   ��66     $ BullseyeArrow=�6�   5<      5>        5?      $
 auto 6)   $ Подробнее��66    5@      �� 5A      .R�5B      �� $ BtnMore��6%   -   5        $��0q�5B   c   $��40��6o   ��66     $	 Dot=�6z   5C      5E      5J      �� 5K   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��Center=�6V   .+�5L      �� $ 
Horizontal=�6   .+�5M      �� -   5         ��Name$ cmbSearchType��5M      
�������$��Stretch=�6F   $��Center=�6b   $	��200��6�    �� SelectedIndex$ 0��6�   $��10,0,0,0q�6�   .@�5N      �� $��Поиск по ID��6#   �� 5O      $$��Поиск по клиенту��6#   �� 5P      $��Поиск по дате ��6#   5Q      �� 5R      -	   5         ��Name$ 
tbSearchID��5R      $
�� 100��6.   $��1q�6<   
�������6P   �� 5S      -
   5        $ 	btnSearch��5S      $��60��6,   
�������
���   �.��5U      '	  !MaterialDesignThemes.Wpf.PackIcon	   	  Kind$ Search=�6.   ���#FF0000$��Center=�6Q   5X      �� 5Y      -   5        $ btnClearSearch��5Y      $��60��61   
�������
���   �.��5[      	  $ Cancel=�6.   ���#FF0000$��Center=�6Q   5^      �� 5_      -   5        $ btnExcel��5_      $��60��6+   
�������
���   �.��5a      	  $ 	FileExcel=�6.   ���	#FF4BA5F0$��Center=�6V   5d      5e      5f      5k      5l      