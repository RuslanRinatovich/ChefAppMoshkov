   M S B A M L   `   `   `  ����N  JChefDeliveryService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FermerGoodsApp.PagesFermerGoodsApp.Pages  5      /    )FermerGoodsApp.Pages.AllFeedBacksPagePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   .local"clr-namespace:FermerGoodsApp.Pages  5      -   5          N� Title$  Товары��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��40 �6   .+�5   
   �� -   5         ��Name$ TextBlockCount��5   !   $��2��6   $��12(�69   $
��Bold"�6G   � 5   
   $��0��6   $��Stretch=�6!   .+�5      �� -   5         ��Name$ 
TBoxSearch��5   "   $	��275��6   $��14(�67   $��3q�6E   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Название��6Q   $	��5 2q�6{   5      �� 5      -   5         ��Name$ ComboCategory��5   #   $	��275��6   $��14(�6:   $��3q�6J   $ Категория��6V   $	��5 2q�6�    �� DisplayMemberPath$ Title��5   .   �� 5!      -   5        $ 	ComboSort��5"      $	��275��5!      $��14(�6#   $��3q�61   $ Сортировать��5"      $	��5 2q�6B   .@�5$      �� $*��$По возрастанию цены��6   �� 5%      $$��По убыванию цены��6   5&      5(      &   System.Windows.Controls.DataGrid  5*   
   -   5          Name$ DtData��5*       $��1��6   $��Stretch=�60   $	��Top=�6N      
IsReadOnly . 	   AutoGenerateColumns	 .  
   SelectionMode$
 Single=�5,   /    �� AlternationCount$ 1��6F      Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6<   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+6<     5/      $ Клиент��6G    6%   �� *Client.GetFio+6G     50      $ Дата��6j    6%   �� *Date+ �� StringFormat$ d�� �� ConverterCulture$ ru-RU��6j     51      $ 
Товар��6C      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6T    6%   �� *	Good.Name+   ElementStyle 52      �� 53      .�54      ��  �� Property � �� �� Value$
 Wrap=�6G   �� 55       �@��TextAlignment$ Justify=�6H   56      58        59      $ Категория��6M   $
 auto 6b    6%   �� *Good.Category.Title+6b     5:      $ 
Отзыв��6>   $ 2* 6O    6%   �� *Info+ 5;      �� 5<      .�5=      ��  � ��$
 Wrap=�6G   �� 5>       �@��TextAlignment$ Justify=�6H   5?      5A      4  .System.Windows.Controls.DataGridTemplateColumn  5B      $
 auto 6)   $ Рейтинг��66      CellTemplate 5C      �� 5D      .R�5E      (  "MaterialDesignThemes.Wpf.RatingBar     Orientation$ 
Horizontal=�5G      
��� ���$��0q�5I         
IsReadOnly .    Value 5F      �� *Rate+5I   *   5J      5L        5M      $
 auto 6)   $ Просмотр��66    5N      �� 5O      .R�5P      ��  ��Name$ BtnEdit��6%   -   5        $��0q�5P   z   ��67   0	  *MaterialDesignThemes.Wpf.PackIconExtension	   	  Kind$	 Eye=�6z   5Q      5S        5T      $
 auto 6)   $ Удалить��66    5U      �� 5V      .R�5W      �� $ 	BtnDelete��6%   -   5        $��0q�5W   �   ��69   	  $ Delete=�6�   5X      5Z      5^      )
  #MaterialDesignThemes.Wpf.DialogHost
  5a   
   -	   5         
 Name$ DialogHostMoreInformation��5a   $       MaterialDesignDarkBackground#��[  5b   $   $	��600��5d   $   $	��600��60   $	��400��5e   $   $	��400��61   $��1q�5f   $   $��Center=�68   $��Center=�6U   $��2��6p   $��2��6�    
  DialogContent 5h      �� 5i      $��20q�6   .+�5j      � .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$
 Dark=�6    5k      �� 5l      $��60 �63   �� 5m      $	��340 �63   .+�5s      �� $��0��6$   $��5q�66    �� TextAlignment$ Center=�6A   $��Stretch=�6Y   $��
Отзыв��5t   (   $
��Wrap=�65   $��Center=�6I   $
��Bold"�5u   (   $��14(�6:   #  MaterialDesignThemes.Wpf.Card  5y      $	��600��6.   $��1��6:   .��5z      �  5{   "   �� 5|   &   $��30 �64   �� 5}   &   $��* �64   �� 5~   &   $��30 �64   �� 5   &   $��30 �64   �� 5�   &   $��30 �64   �� 5�   &   $��30 �64   �� 5�   &    � ColumnDefinitions 5�   "   �� 5�   &   $	��180 �67   �� 5�   &   .+�5�   "     $��10 0 0 0q�6;       IsPreviewValueEnabled  . $��2��6j   $��0��6w    . $
��Left=�6�   
!   Max$! 5��6�    6�   �� *Rate+6�   �� 5�   "   $��16(�6,   $��2��5�   <   $��1��6I    $  MaterialDesignSubtitle2TextBlock#��[ 5�   8   $��Right=�5�   8   ��5�   8   �� " �� Path$" Client.GetFio�5�   8   �� 5�   "   $��Stretch=�6(   $��1��6D   $��Uniform=�6Q   $��2��6c   $��Stretch=�6w   ��6�   �� $" Good.GetPhoto��� 5�   "   $��16(�6,   $��20 0 0 0q�6:   $��0��5�   <   $��0��6I   $��2��6Y   #��[ 5�   8   $��Center=�5�   8   ��5�   8   �� $" 	Good.Name�5�   8   �� 5�   "   $��Disabled=�6/   $
��Auto=�6Y   $��4��6}   $��0��6�   $��2��6�   .��5�   &   �� $��14(�60   $��10 0 0 0q�6>   $
��Wrap=�6g   $��Stretch=�5�   8   ��5�   Q   �� *Info+5�   8   5�   #   5�      5�      5�      �� 5�      -
   5        $ btnOk��5�      $	��100��6@   $��Center=�6L   .��5�      �� # �� Orientation$# 
Horizontal=�6%   $��Center=�6>   .+�5�      '  !MaterialDesignThemes.Wpf.PackIcon  $   Kind$$ Check=�66   ���#FFF$��5q�6U   $��Center=�6`   �� 5�      $��OK��6(   $��Center=�62   5�      5�      5�      5�      5�      5�      