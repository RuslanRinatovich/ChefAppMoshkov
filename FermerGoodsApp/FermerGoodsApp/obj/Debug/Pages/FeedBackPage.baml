   M S B A M L   `   `   `  ����N  JChefDeliveryService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FermerGoodsApp.PagesFermerGoodsApp.Pages  5      '    !FermerGoodsApp.Pages.FeedBackPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:FermerGoodsApp.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N� Title$+  %Мои отзывы на товары��5
      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��50 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DtData��5       $��0��6   $��Stretch=�60   $	��Top=�6N      
IsReadOnly .    AutoGenerateColumns .     SelectionMode$ Single=�5   /    �� AlternationCount$ 1��6F      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6<   	   
Visibility$	 Hidden=�6K   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *Id+6K     5      $ Дата��6j   
 6%   �� *Date+ �� StringFormat$ d�� �� ConverterCulture$ ru-RU��6j     5      $ 
Товар��6C      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6T   
 6%   �� *	Good.Name+   ElementStyle 5      �� 5      .�5      ��  �� Property � �� �� Value$
 Wrap=�6G   �� 5       �@��TextAlignment$ Justify=�6H   5      5!        5"      $ Категория��6M   $
 auto 6b   
 6%   �� *Good.Category.Title+6b     5#      $ 
Отзыв��6>   $ 2* 6O   
 6%   �� *Info+ 5$      �� 5%      .�5&      ��  � ��$
 Wrap=�6G   �� 5'       �@��TextAlignment$ Justify=�6H   5(      5*      4  .System.Windows.Controls.DataGridTemplateColumn  5+      $
 auto 6)   $ Рейтинг��66      CellTemplate 5,      �� 5-      .R�5.      (  "MaterialDesignThemes.Wpf.RatingBar     Orientation$ 
Horizontal=�50      
��� ���$��0q�52         
IsReadOnly .    Value 5/      �� *Rate+52   *   53      55      58      �� 59   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��Center=�6V   .+�5:      �� -   5         ��Name$ btnAdd��5:      $��Добавить��6%   68   �� 5;      -   5        $ 	btnChange��5;      $��Изменить��6(   6;   �� 5<      -   5        $ 	btnDelete��5<      $��Удалить��6(   6:   5=      5>      5?      