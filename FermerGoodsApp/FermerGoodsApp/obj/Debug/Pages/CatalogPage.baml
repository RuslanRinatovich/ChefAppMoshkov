   M S B A M L   `   `   `  ����N  JChefDeliveryService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FermerGoodsApp.PagesFermerGoodsApp.Pages  5      &     FermerGoodsApp.Pages.CatalogPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:FermerGoodsApp.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          N� Title$  Каталог��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��30 �6   .+�5   
   � $��0��6   $��Stretch=�6!   .+�5      �� -   5         ��Name$ 
TBoxSearch��5   &   $	��275��6   $��14(�6;   $��3q�6I   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Название��6U   $	��5 2q�6   5      �� 5      -   5         ��Name$ ComboCategory��5   #   $	��275��6   $��14(�6:   $��3q�6J   $ Категория��6V   $	��5 2q�6�    �� DisplayMemberPath$ Title��5   .   �� 5#      -   5        $ 	ComboSort��5#   A   $	��275��6   $��14(�6'   $��3q�65   $ Сортировать��5$      $	��5 2q�6H   .@�5&      �� $*��$По возрастанию цены��6#   �� 5'      $$��По убыванию цены��6#   5(      5*      �� 5-   
   $	��0.5q�5.         PrimaryHueMidBrush#���   5/      $	��256��50      $	��256��51      $��1��6   }�. ._�53      �� -   5         ��Name$ 
LViewGoods��53      $��Disabled=�54      ��56      �� 57      .R�58      �  � Orientation$ 
Horizontal=�6$   $��Center=�6=   59      ��5;      �� 5<      .R�5=      #  MaterialDesignThemes.Wpf.Card  .��5>      � $��20q�6#   $	��300��6/    5?   "   �� 5@   &   $
��auto �64   �� 5A   &   $	��250 �64   �� 5B   &   $
��auto �64   �� 5C   &   $
��auto �64   .+�5I   "   �� -   5        $��0��5I   )   $
��Left=�66     MaterialDesignFlatButton#���  6Q   .��5J   &   ��  �� Orientation$ 
Horizontal=�61   .+�5K   *   �� $*��$Рейтинг по отзывам: ��64    $  MaterialDesignSubtitle2TextBlock#��[ 6P   (  "MaterialDesignThemes.Wpf.RatingBar  5L   *   $��10 0 0 0q�6F   	   
IsReadOnly	 . 
��� ���
   Value
 5M   7   �� *Rate+5N   '   5O   #   �� 5P   "   $��Stretch=�6(   $��1��6D   $��Uniform=�6Q   $��Stretch=�6c   ��6�   ��  �� Path$ GetPhoto��� 5Q   "    ��Name$ BtnMakeRewiew��6)   -   5        $��1��5R   %   $��5q�62   $��Right=�5S   Z   $	��Top=�6v    � ToolTip$! Оставить отзыв��6�   ��6%   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$ CommentEdit=�y�6�   �� *GetVisibilityBuy+6�   �� 5T   "   $��Right=�6.   $��Bottom=�6J   $ 
Horizontal=�6f   $��8q�6�   $��1��6�   .+�5V   &   �� $ BtnBuy��6-   -   5         , (MaterialDesignFloatingActionAccentButton#��[ 5V   =   $ В корзину��5W   )   y�6=   �� *GetVisibilityBuy+.��5X   *   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
BasketFill=�6E   5[   '   �� 5]   &   $ BtnEditGood��6-   -	   5        #��[ 5]   B   $  Редактировать��5^   )   y�6A   �� *GetVisibilityEdit+.��5_   *     $
 Edit=�6E   5`   '   5c   #   �� 5e   "   $��2��6-   $
��auto��6:   .+�5f   &   �� $
��Auto��6F   $��Center=�6T   $
��Bold"�6o   $��20(�6�   ��60   �� *Name+6�   �� 5g   &   $
��Auto��6b   $��Center=�6p   $��14(�6�   ��60   �� *Weight+ �� StringFormat$ {0} г.��6�     5h   &   
���   �$��3q�6N   .��5i   *   �� $
��Auto��6w   $��Center=�6�   $��18(�6�   $
��Bold"�6�   $��5q�6�   $��Center=�5j   ,   ��5i   4   �� *Price+$ c�� �� ConverterCulture$ ru-RU��5j   ,   5k   '   5l   #   5q      5r      5s      5u      5v      �� 5w   
   -
   5         ��Name$ TextBlockCount��5w   !   $��2��6   $��12(�69   $
��Bold"�6G   )  #MaterialDesignThemes.Wpf.DialogHost  5x   
   -   5          Name$ DialogHostMoreInformation��5x   $      MaterialDesignDarkBackground#��[ 5y   $   $	��600��5{   $   $	��600��60   $	��400��5|   $   $	��400��61   $��1q�5}   $   $��Center=�68   $��Center=�6U   $��2��6p   $��2��6�      DialogContent 5      �� 5�      $��20q�6   .+�5�      � .  (MaterialDesignThemes.Wpf.ColorZoneAssist   Mode$
 Dark=�6    5�      �� 5�      $��30 �63   �� 5�      $��* �63   .+�5�      �� $��0��6$   $��5q�66    �� TextAlignment$ Center=�6A   $��Stretch=�6Y   $��Отзывы��5�   (   $
��Wrap=�66   $��Center=�6J   $
��Bold"�5�   (   $��14(�6:   �� 5�      $��Disabled=�6'   $
��Auto=�6Q   $��1��6u   .��5�      �� -   5         ��Name$ ListBoxRewiews��5�   '   $��Stretch=�6?   ��5�   "   �� 5�   &   .R�5�   *     $	��600��6>   .��5�      �  5�   "   �� 5�   &   $��30 �64   �� 5�   &   $��* �64   .+�5�   "     $��10 0 0 0q�6;      IsPreviewValueEnabled . $��0��6j   	 . $
��Left=�6�   
   Max$ 5��6�   
 6�   �� *Rate+6�   �� 5�   "   $��16(�6,   $��0��5�   <   #��[ 5�   8   $��Right=�5�   8   ��5�   8   �� $ Client.GetFio�5�   8   �� 5�   2   $��14(�6<   $��	10 0 10 0q�6J   $��1��6]   $
��Wrap=�6�   $��Stretch=�5�   8   ��5�   j   �� *Info+5�   8   5�   4   5�   (   5�   '   5�      5�      5�      �� 5�      -   5        $ btnOk��5�      $	��100��6@   $��Center=�6L   .��5�      �� $ 
Horizontal=�6%   $��Center=�6>   .+�5�        $ Check=�66   ���#FFF$��5q�6U   $��Center=�6`   �� 5�      $��OK��6(   $��Center=�62   5�      5�      5�      5�      5�      5�      