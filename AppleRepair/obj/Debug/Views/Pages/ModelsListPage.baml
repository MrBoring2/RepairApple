   M S B A M L   `   `   `  ����F  BAppleRepair, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AppleRepair.Views.PagesAppleRepair.Views.Pages  5      ,    &AppleRepair.Views.Pages.ModelsListPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:AppleRepair.Views.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5        MaterialDesignPaper  N� 
Background#  �  5	   	    N� Title$ ModelsListPage��5       N� 
FontFamily 5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � 	Resources 5        ContextMenuTemplate �� Orientation'  !MaterialDesignThemes.Wpf.PackIcon  Name   Kind��%\  &	       �� 5   
   .R�5      � .+�5      �� $
��Left=�68   ��6   �� *
Color.Name+68   �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5        $
 edit��6.   -   5        $ Pencil=�5   <   ���#43A047
������ $��25��6�   $��Center=�6�   $��25��6�   $��0,0,5,0q�6�   5      5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $
��323* �6   �� 5      $��60 �6   .+�5    
   �  � ColumnDefinitions 5!      �� 5"      $
��160* �6#   �� 5#      $
��200* �6#   �� 5$      $
��120* �6#   .+�5&      �� $	��Top=�6S   $��5,5,5,0q�6k   )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$<	 6Введите название для поиска...��6|   $��16(�6�   $��3��6�   $��30��6�   
 � Cursor$
 IBeam��6�   ��6   �� *Search+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5'      $��Bottom=�6   $��5,5,5,10q�64   .+�5(      �� $��Цвет модели��6   $��14(�6/    �� TextAlignment$ Center=�6=   �� 5)      $��15(�6   ��6*   �� *Colors+ �� SelectedItem 6I   �� *SelectedColor+5*      �� 5+      $��Bottom=�6   $��5,5,5,15q�64   $��3��6F   .+�5,      �� $��Сортировка��6   $��14(�6.   $ Center=�6<   �� 5-      $ 
Horizontal=�6   $��Center=�66   .+�5/      �� $��14(�6    $��5,0,0,0q�6.   $!��По возратсанию��6?   $��Right=�6U   $��Center=�6q   �� 50      $��Center=�6A    d� 	IsChecked 6   �� *IsAcsending+6A   51      52      53      �� 54   
   -   5         ��Name$ addNewModel��54      $��1��6&    �� BitmapScalingMode$ HighQuality=�63    � ToolTip$# Добавить модель��6a   $
��Left=�6{     MaterialDesignIconButton#��[ 6�   $
��15,5q�6�   $��30��6�   $��30��6�   $	��Top=�6�   $

 Hand��6  ��55      �� 56       �� ImageSource$$ /Resources/Images/Vector-1.png��6   $ HighQuality=�6J   58      &   System.Windows.Controls.DataGrid  59   
   $��0,40,0,0q�6      CanUserSortColumns .     CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . $��1��6�      AutoGenerateColumns .  ��6�   �� *DisplayedModels+ 6�   �� *SelectedModel+   Columns 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 67   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *	ModelName+4	  .System.Windows.Controls.DataGridTemplateColumn	  5<      $ Цвет��6)   $ 2* 67    	  CellTemplate# [ 6B   5>      � 5?   
   $��2��6   .+�5@      �� $��Center=�6   $��Bottom=�66   $��5q�6Q   $��40��6\   $ 
Horizontal=�6h   .+�5A      �� -   5        $ ToFirst��5A   ,   
�������$��«��6=   $��50��6I   $��20(�6T   $

 Hand��6x   �� 5B      -   5        $
 Back��5B   ,   
�������$	��←��6:   $��50��6F   $��20(�6Q   $��5,0,0,0q�6_   6p   �� 5C      $��50��6   $��25��6'   $��16(�63   $��5,0,5,0q�6A   $��Center=�6r   $��Center=�6�   $ Center=�6�   ��6R   �� *DisplayedPages+6�   �� 5D      -   5        $ Forward��5D   ,   
�������$	��→��6=   $��50��6I   $��20(�6T   $��0,0,5,0q�6b   6s   �� 5E      -   5        $ ToLast��5E   ,   
�������$��»��6<   $��50��6H   $��20(�6S   6a   5F      5G      5J      5K      