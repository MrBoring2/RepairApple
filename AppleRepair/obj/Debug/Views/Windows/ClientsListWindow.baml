   M S B A M L   `   `   `  ����F  BAppleRepair, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AppleRepair.Views.WindowsAppleRepair.Views.Windows  5   	   1    +AppleRepair.Views.Windows.ClientsListWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:AppleRepair.Views.Windows     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5   	     MaterialDesignPaper#���  5	   	     � WindowStartupLocation$  CenterScreen=�5
   	    � Title$8 2APPLE СЕРВИС | Список клиентов��5   	   $	��684��60   $	��992��6=    � Icon$  /Resources/Images/icon.ico��6I    �� BitmapScalingMode$ HighQuality=�6k   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � 	Resources 5        ContextMenuTemplate �� StringFormat �� Orientation'  !MaterialDesignThemes.Wpf.PackIcon  Name   Kind	 � ToolTip  removeVisibilityConverter
 �� 	Converter  restoreVisibilityConverter��%n  &	       7  7  �� 5   
   .R�5      � .+�5      �� $
��Left=�6_   ��6   �� *PhoneNumber+$ {0:+# (###) ###-####}��6_   �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5        $
 edit��6.   -   5        $ Pencil=�5   <   ���#43A047$ 	 Редактировать��6_   
������ $��25��6�   $��Center=�6�   $��25��6�   $��0,0,5,0q�6�     5      $ remove��6�   -   5        $ Close=�5   �   ���#EF5350
������ $��25��6�   $,	 &Пометить на удаление��6�   $��Center=�6�   $��25��61  y�6.   �� *
IsActive+8
   61    5      $ restore��6�   -   5        $ Restore=�5   �   ���#F57F17
������ $��25��6�   $,	 &Пометить на удаление��6�   $��Center=�6�   $��25��66  y�6.   �� *
IsActive+8
  66  5      5      5      5      .��5      �  � ColumnDefinitions 5   
   �� 5       � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5       $
��485* �6   �� 5!      $��55.04 �6   .+�5#   
   � $��	0,0,0,396q�6   $��2��6"    5$      �� 5%      $
��100* �6#   �� 5&      $
��230* �6#   �� 5'      $
��100* �6#   .+�5)      �� $	��Top=�6   $��5,5,5,0q�6k   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$k eВведите ФИО, email или номер телефона клиента для поиска...��6|   $��16(�6�   $��3��6�   $��30��6�    � Cursor$ IBeam��6  ��6.   �� *Search+ �� UpdateSourceTrigger$ PropertyChanged=�6  �� 5*      $��Bottom=�6   $��5,5,5,10q�64   �� 5+      $��Bottom=�6   $��5,5,5,10q�64   $��3��6F   5,      � 5-   
    5.      �� 5/      $
��100* �6#   �� 50      $
��150* �6#   �� 51      $
��100* �6#   .+�54      �� $��Bottom=�6   $��5,0,5,15q�64   $��1��6F   .+�55      �� $*��$Пометка на удаление��6   $��14(�67    �� TextAlignment$ Center=�6E   �� 56      $��15(�6   ��6*   �� *RemoveCheckCollection+ �� SelectedItem 6X   �� *SelectedRemoveCheck+57      �� 58      $��Bottom=�6   $��5,5,5,25q�64   $��2��6F   .+�59      �� $��Сортировка��6   $��14(�6.   $ Center=�6<   �� 5:      $ 
Horizontal=�6   $��Center=�66   .+�5;      �� $��14(�6    $��5,0,0,0q�6.   $!��По возратсанию��6?   $��Right=�6U   $��Center=�6q   �� 5<      $��14(�6A   $��Center=�6O    d� 	IsChecked 6   �� *IsAcsending+6O   5=      5>      5?      �� 5@   
   -   5         ��Name$ addNewEmployee��5@      $��1��6)   $ HighQuality=�66   $%	 Добавить клиента��6d   $
��Left=�6     MaterialDesignIconButton#��[ 6�   $
��15,5q�6�   $��30��6�   $��30��6�   $	��Top=�6�   $
 Hand��6	  ��5A      �� 5B       �� ImageSource$$ /Resources/Images/Vector-1.png��6   $ HighQuality=�6J   5D      &   System.Windows.Controls.DataGrid  5E   
   $��1��6      
IsReadOnly .    AutoGenerateColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserSortColumns .  $��0,40,0,0q�6�   ��6�   �� *DisplayedClients+ 6�   �� *SelectedClient+   Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Header$ ФИО��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 1.5* 62   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *
FullName+  5H      $ Email��6%   $ * 64    6>   �� *Email+4	  .System.Windows.Controls.DataGridTemplateColumn	  5I      $! Номер телефона��6)   $ * 6A    	  CellTemplate# [ 6K    5K      )
  #System.Windows.Controls.DataGridRow �� 
TargetType  MaterialDesignDataGridRow  �� BasedOn��%N   '
        7  �� 5L      " 
 6   8    .�5M      -   5        5N      5O      5P      � 5Q   
   $��2��6   .+�5R      �� $��Center=�6   $��Bottom=�66   $��5q�6Q   $��40��6\   $ 
Horizontal=�6h   .+�5S      �� -   5        $ ToFirst��5S   ,   
�������$��«��6=   $��50��6I   $��20(�6T   $
 Hand��6x   �� 5T      -   5        $
 Back��5T   ,   
�������$	��←��6:   $��50��6F   $��20(�6Q   $��5,0,0,0q�6_   $
 Hand��6�   �� 5U      $��50��6   $��25��6'   $��16(�63   $��5,0,5,0q�6A   $��Center=�6r   $��Center=�6�   $ Center=�6�   ��6R   �� *DisplayedPages+6�   �� 5V      -   5        $ Forward��5V   ,   
�������$	��→��6=   $��50��6I   $��20(�6T   $��0,0,5,0q�6b   6s   �� 5W      -	   5        $ ToLast��5W   ,   
�������$��»��6<   $��50��6H   $��20(�6S   6a   5X      5Y      �� 5[   
   -
   5        $��Bottom=�5[      $��Отмена��6,   $	��150��6=   
�������$��0,0,5,10q�6\   $��2��6n   $��Right=�6{   $
 Hand��6�   $��32��6�   5\      5]      