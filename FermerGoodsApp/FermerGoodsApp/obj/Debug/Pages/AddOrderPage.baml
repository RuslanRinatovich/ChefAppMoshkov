   M S B A M L   `   `   `  ����N  JChefDeliveryService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FermerGoodsApp.PagesFermerGoodsApp.Pages  5      '    !FermerGoodsApp.Pages.AddOrderPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:FermerGoodsApp.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      X TXceed.Wpf.Toolkit, Version=4.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  6P   -   5          N� Title$  Заявка��5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      $��0 �6   �� 5      -   5         ��Name$ 
rwOrderNum��5   (   $��40 �6   6(   �� 5      $��90 �6   �� 5      $��40 �6   �� 5      $��80 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      -   5        $ rwPrice��5   (   $��40 �6   6(   �� 5      -   5        $ rwServicesName��5   (   $��30 �6   6(   �� 5      -   5        $ 
rwServices��5   '   $��* �6   6'   �� 5      -   5        $ rwButton��5   (   $��60 �6   6(    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      .+�5!   
   �� $��0��6   $��2��6!   �� 5"   
   $��1��6   $��0��6   $��Номер заказа:��6-   $��Center=�6E   $
��Left=�6a   $
��20,0q�6|   $��18(�6�   �� 5#   
   -   5         ��Name$ 	tbOrderId��5#      $��1��6%   $��1��62   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Номер заказа��6V   $��18(�6�   $	��0,2q�6�   ��6B   �� *Id+6�   �� 5&   
   -   5        $ tbClient��5&      $��2��6$   $��0��61   $��2��6A    �� 
IsReadOnly . $ Клиент��6g   $��18(�6�   $��24 10q�6�   �� 5'   
   $��2��6   $��0��6"    �� Orientation$ 
Horizontal=�62   �� 5*   
   $��5��6   $��0��6   $*��$Дата и время заказа:��6-   $��Center=�6L   $
��Left=�6h   $
��20,0q�6�   $��18(�6�   �� 5+   
   $��6��6   $��0��6   $"��Время доставки:��6-   $��Center=�6G   $
��Left=�6c   $
��20,0q�6~   $��18(�6�   &   Xceed.Wpf.Toolkit.DateTimePicker  5,   
   -	   5          Name$ tbStartDate��5,      $��5��63   $��1��6@   $ Дата подачи��5-      $��18(�6K   $	��0,2q�6Y   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]	   Value	 5,   P   �� *	DateStart+5-   Y   "  Xceed.Wpf.Toolkit.TimePicker  5.   
   -
   5        
  Name$
 TimePickerDeleveryTime��5.   7   $��6��6   $��1��6'   $��18(�6W   $	��0,2q�6e   	 6s   �� *DeliveryTime+�� 5/   
   $��7��60   $
��20,0q�6>   $��18(�6L   $��2��6Z   ��6   �� *
StatusName+��6n   �� *Color+�� 51   
   $��8��6   $��0��6   $��Стоимость:��6-   $��Center=�6B   $
��Left=�6^   $
��20,0q�6y   $��18(�6�   $  Xceed.Wpf.Toolkit.DoubleUpDown  52   
   -   5          Name$ TbTotalPrice��52      $��8��62   $��1��6?   $ Стоимость��6O   $��18(�6z   $	��0,2q�6�   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$ C��6�   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   DefaultValue$ 0X�6�   %   DisplayDefaultValueOnEmptyText . ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   
IsReadOnly .    Minimum$ 0X�53   J      Value 6   �� *
TotalPrice+6J   �� 55   
   $��9��6   $��2��6!   $��18(�68   $��Товары��6F    �� TextAlignment$ Center=�6U    �� Padding$ 0,3,0,0q�6l   $
��Bold"�6~   &	   System.Windows.Controls.DataGrid	  58   
   -   5         	 Name$ DtOrderPriceList��58      $��10��6-   $��2��6;   $��Stretch=�6P   $��Stretch=�6l    	  AutoGenerateColumns .   	  
IsReadOnly .  	  HeadersVisibility$	 All=�6�    	  CanUserAddRows .   	  Columns 5?      1
  +MaterialDesignThemes.Wpf.DataGridTextColumn
  5@      ,  &System.Windows.Controls.DataGridColumn   Header$ Категория ��6[      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6o   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Key.Category.Title+6o   
  5A      $ Товар: ��6Q   $ * 6b    64   �� *
Key.Name+6b   
  5B      $# Стоимость за шт.��6~   $ * 6�    64   �� *	Key.Price+ �� StringFormat$ c�� �� ConverterCulture$ ru-RU��6�   4  .System.Windows.Controls.DataGridTemplateColumn  5E      $
 auto 6)   $ Количество��66      CellTemplate 5F      �� 5G      .R�5H      �� $ 
Horizontal=�6)   .+�5I   "   ��   ��Name$  BtnAdd��6)   -   5        $��32��5I   g   $��0q�6r   ��69   0  *MaterialDesignThemes.Wpf.PackIconExtension  !   Kind$
! Plus=�" � DataContext" 6~   �� *Key+6�   �� 5J   "    . $��40��6Y   $��12(�6d   $
��Bold"�6r   $��Center=�6�   $��Center=�6�   ��6*   �� *Value.Count+6�   �� 5K   "   $  	BtnDelete��6)   -   5        $��0q�5K   k   $��32��6w   ��6<     $! Minus=�" 6�   �� *Key+6�   5L      5M      5O      
  5P      $ 
Итого��6   $ * 6�    64   �� *Value.Total+$ c��$ ru-RU��6�     5Q      $
 auto 6)   $ Удалить��66    5R      �� 5S      .R�5T      �� $  BtnDeleteItem��6%   -   5        $��60��5T   l   ��6<     $! Delete=�" 6w   �� *Key+6�   5U      5W      5Y      �� 5[   
   $ 
Horizontal=�6   $��11��6/   $��2��6=   $��10q�6Q   $��Center=�6]   .+�5\      �� -   5        $  btnSave��5\      $��Сохранить��6'   $��Center=�6<   $��Bottom=�6Y   $	��120��6t   6�   �� 5]      -   5        $  	btnCancel��5]      $!��Отменить заказ��6)   $��Center=�6C   $��Bottom=�6`   $	��160��6{   6�   �� 5^      -   5        $  btnExcel��5^      $��Квитанция��6(   $��Center=�6=   $��Bottom=�6Z   $	��120��6u   6�   5_      %  Xceed.Wpf.Toolkit.MaskedTextBox  5a   
   -   5        #  Name$# TbPhone��5a      $   Mask$$ +0 (000) 000-00-00��5b         MaterialDesignTextBox#���   6,   $��18(�6\   $��20 5 0 0q�5c      $��Center=�6&   $��3��6A   $��0��6N   $��2��6^   ��5a   0   �� *ContactPhone+5c   ^   �� 5d   
   -   5        $ 	TbAddress��5d      $��4��6%   $��0��62   $��2��6B   $ 
Адрес��6o   $��18(�6�   $��24 10q�6�   ��6V   �� *	Address+6�   5k      5l      