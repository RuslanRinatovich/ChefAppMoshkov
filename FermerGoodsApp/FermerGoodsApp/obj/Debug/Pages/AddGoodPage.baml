   M S B A M L   `   `   `  ����N  JChefDeliveryService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FermerGoodsApp.PagesFermerGoodsApp.Pages  5      &     FermerGoodsApp.Pages.AddGoodPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:FermerGoodsApp.Pages     5        N� Title$:  4Добавление и редактирование��5	       N� FontSize$ 14(�6*   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      $��30 �6   �� 5      �� 5      $��60 �6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      .+�5   
   �� $��0��6   $��2��6!   �� 5   
   -   5         ��Name$ ComboCategory��5       �� DisplayMemberPath$ Title��5      $��2��6   $��1��6)    �� SelectedValuePath$ Id��5       �� SelectedItem 5   *   �� *
Category+5      �� 5   
   $��Вес��6   $��Center=�6   $
��20 0q�6;   $��3��6I   $��0��6V   �� 5    
   -   5         ��Name$ TextBoxWeight��5       $	��100��6   $��3��65   $��1��6B   $
��Left=�6R   ��5!      �� *Weight+	 �� StringFormat$	 {0:f2}��
 �� ConverterCulture$
 ru-RU���� 5#   
   -   5         ��Name$ BtnSave��5#      $��6��6"   $��Сохранить��6/   $��Center=�6C   $��140,5,340,0q�5$      $	��Top=�6   $	��120��6.   $��1��5%      �� 5&   
   -   5         ��Name$ TextBlockGoodId��5&      $��0��6-   $��0��6:   $	��ID:��6J   $
��20 0q�6U   �� 5'   
   $��1��6   $��0��6!   $��Название:��61   $
��20 0q�6B   �� 5(   
   $��2��6   $��0��6!   $��Категория:��61   $
��20 0q�6C   �� 5)   
   $��4��6   $��0��6!   $��Стоимость:��61   $
��20 0q�6C   �� 5*   
   $��5��6   $��0��6!   $,��&Главное изображение:��61   $
��20 0q�5+      $��30��6   $	��Top=�6   �� 5,   
   -   5        $ TextBoxGoodId��5,      $��0��6A   $��1��6N   $	��0,2q�5-       �� 
IsReadOnly . ��5,   )   �� *GoodId+5-      �� 5.   
   -   5        $ TextBoxGoodName��5.      $��1��6A   $��1��5/      $	��0,2q�6   ��5.   +   �� *Name+5/      �� 50   
   -   5         ��Name$ 
ImagePhoto��50      $��5��6@   $��1��6M   $��Stretch=�51      $��Stretch=�6   ��50   $   �� *
GetPhoto+51      �� 52   
   -   5        $ BtnLoad��52      $��5��6"   $��0��6/   $��	20,30,0,0q�6?   $
��Left=�53      $	��Top=�6   $��Загрузить��54      �� 55   
   -	   5        $ TextBoxPrice��55      $��4��56      $��1��6   $	��0,2q�6   ��55   (   �� *Price+$	 c��$
 ru-RU��56      57      58      