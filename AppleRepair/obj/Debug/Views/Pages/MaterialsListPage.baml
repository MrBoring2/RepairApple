   M S B A M L   `   `   `  ����F  BAppleRepair, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AppleRepair.Views.PagesAppleRepair.Views.Pages  5      /    )AppleRepair.Views.Pages.MaterialsListPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:AppleRepair.Views.Pages     5      _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      &    AppleRepair.Views.Pages.BasePage    Loaded$  BasePage_Loaded��5   1      MaterialDesignBody#���   5        MaterialDesignPaper N� 
Background# �  5	   	    N� Title$ MaterialsListPage��5       N� 
FontFamily 5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension   � 	Resources 5        ContextMenuTemplate �� StringFormat �� Orientation'  !MaterialDesignThemes.Wpf.PackIcon  Name   Kind	 � ToolTip  removeVisibilityConverter
 �� 	Converter  restoreVisibilityConverter��%]  &	       7  7  �� 5   
   .R�5      � .+�5      �� $
��Left=�6L   ��6   �� *Amount+$ 	{0} шт.��6L   �� 5      $ 
Horizontal=�6   $��Right=�66   .+�5        $
 edit��6.   -   5        $ Pencil=�5   <   ���#43A047$ 	 Редактировать��6_   
������ $��25��6�   $��Center=�6�   $��25��6�   $��0,0,5,0q�6�     5      $ remove��6�   -   5        $ Close=�5   �   ���#EF5350
������ $��25��6�   $,	 &Пометить на удаление��6�   $��Center=�6�   $��25��61  y�6.   �� *
IsActive+8
   61    5      $ restore��6�   -   5        $ Restore=�5   �   ���#F57F17
������ $��25��6�   $,	 &Пометить на удаление��6�   $��Center=�6�   $��25��66  y�6.   �� *
IsActive+8
  66  5      5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $
��323* �6   �� 5      $��60 �6   .+�5!   
   �  � ColumnDefinitions 5"      �� 5#      $
��200* �6#   �� 5$      $
��200* �6#   �� 5%      $
��170* �6#   .+�5'      �� $	��Top=�6S   $��5,5,5,0q�6k   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$< 6Введите название для поиска...��6|   $��16(�6�   $��3��6�   $��30��6�    � Cursor$ IBeam��6�   ��6   �� *Search+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5(      $��Bottom=�6   $��5,5,5,10q�64   .+�5)      �� $��Тип материала��6   $��14(�61    �� TextAlignment$ Center=�6?   �� 5*      $��15(�6   ��6*   �� *MaterialTypes+ �� SelectedItem 6P   �� *SelectedMaterialType+5+      �� 5,      $��Bottom=�6   $��5,5,5,10q�64   $��1��6F   .+�5-      �� $*��$Пометка на удаление��6   $��14(�67   $ Center=�6E   �� 5.      $��15(�6   ��6*   �� *RemoveCheckCollection+ 6X   �� *SelectedRemoveCheck+5/      �� 50      $��Bottom=�6   $��5,5,5,10q�64   $��3��6F   .+�51      �� $��Сортировка��6   $��14(�6.   $ Center=�6<   �� 52      $ 
Horizontal=�6   .+�53      �� $��15(�6    �� DisplayMemberPath$ Title��6P   $	��180��6j   ��6-   �� *
SortParams+ 6v   �� *SelectedSort+�� 55      $��14(�6    $��5,0,0,0q�6.   $!��По возратсанию��6?   $��Right=�6U   $��Center=�6q   �� 56      $��Center=�6A    d� 	IsChecked 6   �� *IsAcsending+6A   57      58      59      �� 5:   
   -   5         ��Name$ addNewMaterial��5:      $��1��6)    �� BitmapScalingMode$ HighQuality=�66   $'	 !Добавить материал��6d   $
��Left=�6�     MaterialDesignIconButton#��[ 6�   $
��15,5q�6�   $��30��6�   $��30��6�   $	��Top=�6�   $
 Hand��6
  ��5;      �� 5<       �� ImageSource$$ /Resources/Images/Vector-1.png��6   $ HighQuality=�6J   5>      �� 5?   
   -   5        $ deliveryMaterial��5?   8   $��1��6R   $ HighQuality=�6_   $+	 %Поставка материалов��6�   $
��Left=�6�   #��[ 6�   $
��55,5q�6�   $��35��6  $��35��6  $	��Top=�6  $
 Hand��65  y�6   �� *AdminVisibility+��5@      �� 5A      $: 4/AppleRepair;component/Resources/Images/delivery.png��6   $ HighQuality=�6`   5C      &   System.Windows.Controls.DataGrid  5D   
   $��0,40,0,0q�6      CanUserSortColumns .     CanUserAddRows .     CanUserDeleteRows .     
IsReadOnly . $��1��6�      AutoGenerateColumns .  ��6�   �� *DisplayedMaterials+ 6�   �� *SelectedMaterial+   Columns 5E      0  *System.Windows.Controls.DataGridTextColumn  5F      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 67   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6B   �� *Name+  5G      $ Цена��6%   $ * 63    6=   �� *Price+$ {0} ₽��4
  .System.Windows.Controls.DataGridTemplateColumn
  5H      $, &Количество на складе��6)   $ * 6G     
  CellTemplate#  [ 6Q    5J      )  #System.Windows.Controls.DataGridRow! �� 
TargetType  MaterialDesignDataGridRow" �� BasedOn��%N   '        7  �� 5K      "!  6   8"   .�5L      -   5        5M      5N      5O      � 5P   
   $��2��6   .+�5Q      �� $��Center=�6   $��Bottom=�66   $��5q�6Q   $��40��6\   $ 
Horizontal=�6h   .+�5R      �� -   5        $ ToFirst��5R   ,   
�������$��«��6=   $��50��6I   $��20(�6T   6b   �� 5S      -   5        $
 Back��5S   ,   
�������$	��←��6:   $��50��6F   $��20(�6Q   $��5,0,0,0q�6_   6p   �� 5T      $��50��6   $��25��6'   $��16(�63   $��5,0,5,0q�6A   $��Center=�6r   $��Center=�6�   $ Center=�6�   ��6R   �� *DisplayedPages+6�   �� 5U      -	   5        $ Forward��5U   ,   
�������$	��→��6=   $��50��6I   $��20(�6T   $��0,0,5,0q�6b   6s   �� 5V      -
   5        $ ToLast��5V   ,   
�������$��»��6<   $��50��6H   $��20(�6S   6a   5W      5X      5[      5\      