   M S B A M L   `   `   `  ����F  BAppleRepair, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AppleRepair.Views.PagesAppleRepair.Views.Pages  5      /    )AppleRepair.Views.Pages.EmployeesListPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:AppleRepair.Views.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5   	     MaterialDesignPaper  N� 
Background#  �  5	   	    N� Title$ EmployeesListPage��5       N� 
FontFamily 5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � 	Resources 5        ContextMenuTemplate �� Orientation'  !MaterialDesignThemes.Wpf.PackIcon  Name   Kind � ToolTip  removeVisibilityConverter �� 	Converter  restoreVisibilityConverter��%P  &	       7  7  �� 5   
   .R�5      � .+�5      �� $
��Left=�67   ��6   �� *	Role.Name+67   �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5        $
 edit��6.   -   5        $ Pencil=�5   <   ���#43A047$  Редактировать��6_   
������ $��25��6�   $��Center=�6�   $��25��6�   $��0,0,5,0q�6�     5      $ remove��6�   -   5        $ Close=�5   �   ���#EF5350
������ $��25��6�   $, &Пометить на удаление��6�   $��Center=�6�   $��25��61  y�6.   �� *
IsActive+8   61    5      $ restore��6�   -   5        $ Restore=�5   �   ���#F57F17
������ $��25��6�   $, &Пометить на удаление��6�   $��Center=�6�   $��25��66  y�6.   �� *
IsActive+8  66  5      5      5      5      .��5      � 	 � RowDefinitions	 5   
   �� 5      $	��100 �6   �� 5      $
��323* �6   �� 5      $��60 �6   .+�5!   
   � 
 � ColumnDefinitions
 5"      �� 5#      $
��160* �6#   �� 5$      $
��200* �6#   �� 5%      $
��120* �6#   .+�5'      �� $	��Top=�6S   $��5,5,5,0q�6k   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$< 6Введите название для поиска...��6|   $��16(�6�   $��3��6�   $��30��6�    � Cursor$ IBeam��6�   ��6   �� *Search+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5(      $��Bottom=�6   $��1��64   $��5,5,5,15q�6D   .+�5)      �� $*��$Пометка на удаление��6   $��14(�67    �� TextAlignment$ Center=�6E   �� 5*      $��15(�6   ��6*   �� *RemoveCheckCollection+ �� SelectedItem 6X   �� *SelectedRemoveCheck+5+      �� 5,      $��Bottom=�6   $��5,5,5,25q�64   $��2��6F   .+�5-      �� $��Сортировка��6   $��14(�6.   $ Center=�6<   �� 5.      $ 
Horizontal=�6   $��Center=�66   .+�5/      �� $��14(�6    $��5,0,0,0q�6.   $!��По возратсанию��6?   $��Right=�6U   $��Center=�6q   �� 50      $��14(�6A   $��Center=�6O    d� 	IsChecked 6   �� *IsAcsending+6O   51      52      53      �� 54   
   -   5         ��Name$ addNewEmployee��54      $��1��6)    �� BitmapScalingMode$ HighQuality=�66   $# Добавить модель��6d   $
��Left=�6~     MaterialDesignIconButton#��[ 6�   $
��15,5q�6�   $��30��6�   $��30��6�   $	��Top=�6�   $
 Hand��6  ��55      �� 56       �� ImageSource$$ /Resources/Images/Vector-1.png��6   $ HighQuality=�6J   58      &   System.Windows.Controls.DataGrid  59   
   $��0,40,0,0q�6      CanUserSortColumns .     CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . $��1��6�      AutoGenerateColumns .  ��6�   �� *DisplayedEmployees+ 6�   �� *SelectedEmployee+   Columns 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ ФИО��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 62   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *
FullName+4	  .System.Windows.Controls.DataGridTemplateColumn	  5<      $ Роль��6)   $ 2* 67    	  CellTemplate# [ 6B   5?      � 5@   
   $��2��6   .+�5A      �� $��Center=�6   $��Bottom=�66   $��5q�6Q   $��40��6\   $ 
Horizontal=�6h   .+�5B      �� -   5        $ ToFirst��5B   ,   
�������$��«��6=   $��50��6I   $��20(�6T   $
 Hand��6x   �� 5C      -   5        $
 Back��5C   ,   
�������$	��←��6:   $��50��6F   $��20(�6Q   $��5,0,0,0q�6_   6p   �� 5D      $��50��6   $��25��6'   $��16(�63   $��5,0,5,0q�6A   $��Center=�6r   $��Center=�6�   $ Center=�6�   ��6R   �� *DisplayedPages+6�   �� 5E      -   5        $ Forward��5E   ,   
�������$	��→��6=   $��50��6I   $��20(�6T   $��0,0,5,0q�6b   6s   �� 5F      -   5        $ ToLast��5F   ,   
�������$��»��6<   $��50��6H   $��20(�6S   6a   5G      5H      5K      5L      