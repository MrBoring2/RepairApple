   M S B A M L   `   `   `  ����F  BAppleRepair, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AppleRepair.Views.PagesAppleRepair.Views.Pages  5      ,    &AppleRepair.Views.Pages.OrdersListPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:AppleRepair.Views.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      &    AppleRepair.Views.Pages.BasePage    Loaded$  BasePage_Loaded��5   1      MaterialDesignBody#���   5        MaterialDesignPaper N� 
Background# �  5	   	    N� Title$ 	OrderPage��5       N� 
FontFamily 5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � 	Resources 5        ContextMenuTemplate �� Orientation'  !MaterialDesignThemes.Wpf.PackIcon  Name   Kind � ToolTip)  #System.Windows.Controls.DataGridRow	 �� 
TargetType  MaterialDesignDataGridRow
 �� BasedOn �� Property �� Value  colorFromDate �� 	Converter��%�  &	       '      7  7  �� 5   
   .R�5      � .+�5      �� $
��Left=�64   ��6   �� *Status+64   �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5        $ check��6.   -   5        $ Check=�5   =   ���#43A047$# Завершить заказ��6_   
������ $��25��6�   $��Center=�6�   $��25��6�   $��5,0,5,0q�6�     5      $ cancel��6.   -   5        $ Cancel=�5   >   ���#FF0000
������ $! Отменить заказ��6z   $��25��6�   $��Center=�6�   $��25��6�   $��5,0,5,0q�6�     5      $ restore��6.   -   5        $ Restore=�5   ?   ���#FF9F57
������ $) #Восстановить заказ��6|   $��25��6�   $��Center=�6�   $��25��6�   $��5,0,5,0q�6�   5      5      5      �� 5   
   "	  6   8
   .�5      ��  � �� 6+   �� *.+8  -   5        5      5      .��5       �  � RowDefinitions 5!   
   �� 5"      $	��100 �6   �� 5#      $
��323* �6   �� 5$      $��60 �6   .+�5&   
   �  � ColumnDefinitions 5'      �� 5(      $
��100* �6#   �� 5)      $
��100* �6#   �� 5*      $
��100* �6#   .+�5,      �� $	��Top=�6   $��5,5,5,0q�6.   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$` ZВведите номер заказа или ФИО клиента для поиска...��6?   $��16(�6�   $��2��6�   $��30��6�    � Cursor$ IBeam��6�   ��6�   �� *Search+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5-      $��Bottom=�6   $��5,5,5,10q�64   .+�5.      �� $#��Модель телефона��6   $��14(�63    �� TextAlignment$ Center=�6A   �� 5/      $��14(�6   ��6)   �� *Models+ �� SelectedItem 6H   �� *SelectedModel+50      �� 51      $��Bottom=�6   $��1��64   $��5,5,5,10q�6D   .+�52      �� $��Статус заказа��6   $��14(�61   $ Center=�6?   �� 53      $��14(�6   ��6)   �� *
Statuses+ 6J   �� *SelectedStatus+54      �� 55      $��Bottom=�6   $��5,5,5,10q�64   $��3��6F   .+�56      �� $��Сортировка��6   $��14(�6.   $ Center=�6<   �� 57      $ 
Horizontal=�6   $��Center=�66   .+�59      �� $��14(�6    $��5,0,10,0q�6.   $!��По возрастанию��6@   $��Right=�6V   $��Center=�6r   �� 5:      $��14(�6   $��Right=�6O    d� 	IsChecked 6-   �� *IsAcsending+6O   5;      5<      5?      �� 5@   
   -   5         ��Name$ addNewOrder��5@      $��1��6&    �� BitmapScalingMode$ HighQuality=�63   $! Добавить заказ��6a   $
��Left=�6z     MaterialDesignIconButton#��[ 6�   $
��15,5q�6�   $��30��6�   $��30��6�   $	��Top=�6�   $
 Hand��6  ��5A      �� 5B       �� ImageSource$$ /Resources/Images/Vector-1.png��6   $ HighQuality=�6J   5D      &   System.Windows.Controls.DataGrid  5E   
      
IsReadOnly .    SelectionMode$ Single=�6%      AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserSortColumns .  $��1��6�   $��0,40,0,0q�6  ��6�   �� *DisplayedOrders+ 6�   �� *SelectedOrder+   Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn    Header$  Номер заказа��6%   !   Width5	  /System.Windows.Controls.DataGridLengthConverter$
! 0.8*	 6;   1
  +System.Windows.Controls.DataGridBoundColumn" 
  Binding" 6H   �� *Id+  5H      $  Клиент��6%   $
! 1.7*	 65   " 6B   �� *Client.FullName+  5I      $#  Модель телефона��6%   $! *	 6>   " 6H   �� *PhoneModel.ModelName+  5J      $  Начала заказа��6%   $! *	 6<   " 6F   �� *	StartDate+# �� StringFormat$# {0:dd.MM.yyy HH:mm:ss}��  5K      $%  Окончание заказа��6%   $! *	 6?   " 6I   �� *	EndDate+$# {0:dd.MM.yyy HH:mm:ss}��4  .System.Windows.Controls.DataGridTemplateColumn  5L      $  Статус��6)   $! 2*	 69   $   CellTemplate#$ [ 6D   5N      � 5O   
   $��2��6   .+�5P      �� $��Center=�6   $��Bottom=�66   $��5q�6Q   $��40��6\   $ 
Horizontal=�6h   .+�5Q      �� -   5        $ ToFirst��5Q   ,   
�������$��«��6=   $��50��6I   $��20(�6T   $
 Hand��6x   �� 5R      -   5        $
 Back��5R   ,   
�������$	��←��6:   $��50��6F   $��20(�6Q   $��5,0,0,0q�6_   $
 Hand��6�   �� 5S      $��50��6   $��25��6'   $��16(�63   $��5,0,5,0q�6A   $��Center=�6r   $��Center=�6�   $ Center=�6�   ��6R   �� *DisplayedPages+6�   �� 5T      -   5        $ Forward��5T   ,   
�������$	��→��6=   $��50��6I   $��20(�6T   $��0,0,5,0q�6b   6s   �� 5U      -	   5        $ ToLast��5U   ,   
�������$��»��6<   $��50��6H   $��20(�6S   6a   5V      5X      �� 5Y   
   $ 
Horizontal=�6   $��2��6.   $��Right=�6;   $��0,20,5,5q�6W   5[      5\      