   M S B A M L   `   `   `  ����N  JChefDeliveryService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:FermerGoodsApp.WindowsFermerGoodsApp.Windows  5   	   .    (FermerGoodsApp.Windows.AddFeedBackWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:FermerGoodsApp.Windows     5   	   X TXceed.Wpf.Toolkit, Version=4.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  
Отзыв��5   
    � WindowStartupLocation$ CenterScreen=�6   $	��450��6>   $	��600��6N   $	��450��6^   $	��600��6k    � Icon$7 1/ChefDeliveryService;component/Resources/logo.png��6�   .��5      �  � RowDefinitions 5   
   �� 5      $��29 �6   �� 5      $��35 �6   �� 5      $��35 �6   �� 5      $	��200 �6   �� 5      $��35 �6   �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $	��187 �6   �� 5      .+�5   
   �� $��0��6   $��0��6!   $&�� Категория товара:��61   $
��20 0q�6K   �� 5   
   -   5         ��Name$ ComboCategory��5      $��0��6Q   $��1��5       �� DisplayMemberPath$ Title��6    �� SelectedValuePath$ Id��5       �� SelectedItem 5   *   �� *Good.Category+5      �� 5    
   $��1��6   $��0��6!   $��Товар:��61   $
��20 0q�6@   �� 5%   
   -   5        $ 	ComboGood��5%      $��14(�6&   $��3q�64   $ Id��5&      $��1��6*   $��1��67    6G   �� *Good+��5'      �� 5(      .R�5)      �� 	 �� Orientation$	 
Horizontal=�6!   .+�5*      �� $��15��6<   $��5 0 5 0q�6G   ��6    �� *
GetPhoto+6G   �� 5+      ��6$   �� *Name+5,      5-      5/      �� 51   
   $��2��6   $��0��6!   $��	Дата:��61   $
��20 0q�6?   &   Xceed.Wpf.Toolkit.DateTimePicker  52   
   -   5        
  Name$
 DatePickerDate��52      $��1��6v   $��2��6�   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.DateTime, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 67   �� *Date+ �� ConverterCulture$ ru-RU�� �� StringFormat$ d��6�   �� 54   
   $��
Отзыв��6   $��3��6"   $��0��6/   $	��Top=�6@   $
��20 0q�6X   �� 57   
   $��Рейтинг��6   $��4��6$   $��0��61   $��Center=�6B   $
��20 0q�6]   �� 58      $��1��6
   $��3��6    �� TextWrapping$
 Wrap=�6>   $	��Top=�6R   $
��Left=�6q   ��6(   �� *Info+6q   �� 59   
   $��Center=�6   $	 
Horizontal=�62   $��5��6K   $��2��6X   $��127,0,103,0q�6l   $	��162��6�   .+�5:      �� -   5         �� 	IsDefault . $��60��5:   ;   $��5q�6I   $��OK��6T   �� 5;       �� IsCancel . $��60��6%   $��5q�63   $��Отмена��6>   5<      (  "MaterialDesignThemes.Wpf.RatingBar  5=   
   -   5          Name$ RatingBarRate��5=   @   $��4��6#   $��1��60      Orientation$ 
Horizontal=�5?      
��� ���$��0q�5A         Value 5>   	   �� *Rate+5A      5B      5C      