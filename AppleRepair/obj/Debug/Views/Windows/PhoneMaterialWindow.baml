   M S B A M L   `   `   `  ����F  BAppleRepair, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AppleRepair.Views.WindowsAppleRepair.Views.Windows  5   	   3    -AppleRepair.Views.Windows.PhoneMaterialWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:AppleRepair.Views.Windows     5   	   _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fHmde>https://spiegelp.github.io/MaterialDesignExtensions/winfx/xaml  5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � WindowStartupLocation$  CenterScreen=�5       � 
ResizeMode$ NoResize=�5	         MaterialDesignBody#���   5
        MaterialDesignPaper#���  5   	    � Title$B <APPLE СЕРВИС | Добавление материала��5   	   $	��580��65   $
��1000��6B    � Icon$  /Resources/Images/logo.png��6O   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      �  � ColumnDefinitions 5   
   �� 5      .+�5   
   �� $��20,20,20,20q�6    �� CornerRadius$ 30��6&   ���#9E9E9E$��1q�6N   ._�5      �  5      �� 5      $
��276* �6'   �� 5      $
��203* �6'   .+�5      �� $��0��6   .+�5      �� $��14(�6    $��Название��6.   $��
15,25,15,0q�6>   �� 5       �� 
IsReadOnly . $��16(�6N   $��
15,0,15,15q�6\   $	��Top=�6p    � Cursor$ IBeam��6�   ��60   �� *MaterialName+6�   � 5       5      �� 5       $
��191* �6/   �� 5!      $	��85* �6/   .+�5#      �� $��1��6%   .+�5$      �� $��14(�6(   $��Цена��66   $��	15,5,15,0q�6B   �� 5%      $��	15,0,10,0q�6=   ��6&   �� *Price+6=   5&      �� 5'      $��1��6%   .+�5(      �� $��14(�6(   $��Количество��66   $��Center=�6H   >  8MaterialDesignExtensions.Controls.OversizedNumberSpinner  5)      $��60��6^   $��14(�6j   
�������$��Center=�6�   $��40��6�   
   Max$	 400��6�   
	   Min$	 1��6�   $��5q�6�   {�69   �� *IsOperationAdd+
   Value
 6�   �� *Amount+ �� Mode$ TwoWay=�6�   5*      5+      �� 5,      .+�5-      �� $��14(�6J   $"��Характеристики��6X   $��	15,0,15,0q�6n   y�6$   �� *EditVisibility+6n   �� 5.      $��	15,0,15,0q�6�   $ IBeam��6�   y�6"   �� *EditVisibility+��6H   �� *Description+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5/      50      � 51      $��1��6   
������ .+�53      #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 20Q�6*   $��15q�6C   ���	#FFF9F9F9+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�6f      ShadowEdges$	 All=�6�   .��54      �� .��55      �� .+�56   "   �� $��14(�6,   $��Тип материала��6:   $��
10,10,10,0q�6O   �� 57   "   $��
10,0,10,10q�6P   $��16(�6�    �� DisplayMemberPath$
 Name��6�   {�6+   �� *IsOperationAdd+��6d   �� *MaterialTypes+ �� SelectedItem 6�   �� *SelectedMaterialType+6�   �� 58   "   $��14(�6,   $#��Модель телефона��6:   $��
10,10,10,0q�6Q   �� 59   "   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$# Выберите модель��6P   $��
10,0,10,10q�6�   $��16(�6�   {�6+   �� *IsOperationAdd+��6�   �� *Models+ 6�   �� *SelectedModel+�� 5;   "   $��10q�6P    ' #MaterialDesignNavigationListBoxItem#��[ 6\   $��Stretch=�6�   $��Disabled=�6  $��Stretch=�6U  $��Stretch=�6s  {�6+   �� *IsOperationAdd+��6�   �� *SelectedModels+ 6�   �� *SelectedModelInList+��5<   &   �� 5=   *    �� DataType" ��67   .R�5>   .   � .+�5?   2   �� ��6<   �� '  !MaterialDesignThemes.Wpf.PackIcon  5@   2   -   5           Kind$ Close=�5@   J   ���#EF5350
������ $��30��6�   $��30��6�   $��Right=�6�   6�   5A   /   5B   +   5D   #   5E      5F      5G      5H      �� 5I      -   5         ��Name$
 Save��5I      $��Сохранить��6'   $��Bottom=�6;   $��15q�6V   $��Center=�6b   $	��200��6   
�������$
 Hand��6�   5J      5K      5L      5M      