   M S B A M L   `   `   `  ����F  BAppleRepair, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AppleRepair.Views.WindowsAppleRepair.Views.Windows  5   	   1    +AppleRepair.Views.Windows.FinishOrderWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:AppleRepair.Views.Windows     5   	   _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fHmde>https://spiegelp.github.io/MaterialDesignExtensions/winfx/xaml  5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
     � WindowStartupLocation$  CenterScreen=�5	       � 
ResizeMode$ NoResize=�5
         MaterialDesignBody#���   5        MaterialDesignPaper#���  5   	    � Title$8 2APPLE СЕРВИС | Создание заказа��5      $	��623��6/   $
��1300��6<    � Icon$  /Resources/Images/logo.png��6I   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      �  � ColumnDefinitions 5   
   �� 5      .+�5   
   �� $��20,20,20,20q�6    �� CornerRadius$ 30��6&   ���#9E9E9E$��1q�6N   ._�5      �  5      �� 5      $
��276* �6'   �� 5      $
��203* �6'   �� 5      $
��203* �6'   .+�5      �� $��0��6   .+�5      �� $��14(�6    $��Клиент��6.   $��
15,25,15,0q�6<   � 5       5       �� 5!      .+�5#      �� $��14(�6"   $	��Top=�60   {�.  $��1��6�   $��	15,5,15,0q�6�    � Cursor$ IBeam��6�   ��6H   �� *ClientFullName+ �� Mode$ OneWay=�6�   5$      �� 5&      $��14(�6    $#��Модель телефона��6.   $��
15,25,15,0q�6E   � 5'       5(      �� 5)      .+�5+      �� {�.  $
��15,0q�6]   $��15(�6k   ��6"   �� *
PhoneModel+$ OneWay=�6k   5,      � 5/       50      �� 51      $
��100* �6/   �� 52      $
��100* �6/   .+�54      �� $��14(�6$   $(��"Дата начала заказа��62   $��
15,5,15,50q�6L   $��1��6`   �� 56      $��14(�6$   $.��(Дата окончания заказа��62   $��
15,5,15,50q�6O   $��1��6c   (  "System.Windows.Controls.DatePicker  57      $��14(�6%   $��15,5,5,5q�63      IsDropDownOpen .  {�.  	   SelectedDate	 6E   �� *	StartDate+$ OneWay=�6�     58      $��1��6%   $��14(�65   $��	15,5,15,5q�6C    .  {�.  	 6V   �� *	EndDate+$ OneWay=�6�   59      �� 5;      .+�5<      �� $��14(�6$   $'��!Описание проблемы��62   $��15,0,5,0q�6K   �� 5=      -   5        
 ��Name$
 descriptionText��5=   Z   $��14(�6L   $	��Top=�6s   $��	15,0,15,0q�6�   {�.  $ IBeam��6�   ��6"   �� *Description+$ OneWay=�6�   5>      5?      #  MaterialDesignThemes.Wpf.Card  5@      $��1��6&      UniformCornerRadius$ 20Q�66   $��15q�6O   ���	#FFF9F9F9+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�6r      ShadowEdges$	 All=�6�   .��5A      �� .��5B      �� .+�5C      �� $��16(�6(   $��Услуги��66   $��
10,10,10,0q�6D   �� 5D      $��10q�6(     listViewItemStyle#��[ 64   $��Stretch=�6�   {�.  $��Disabled=�6�   $��Stretch=�6�   $��Stretch=�6  ��6l   �� *
Services+��5E   "   �� 5F   &    �� DataType" ��63   .R�5G   *   � .+�5H   .   �� $��Center=�6N   $��14(�6i   $
��Wrap=�6w   $
��10,5q�6�   ��68   �� *Name+6�   5I   +   5J   '   5L      5M      5N      5O      � 5P      $��2��6   
������ .+�5R        $ 20Q�6*   $��15q�6C   ���	#FFF9F9F9$ Depth2=�6f   $	 All=�6�   .��5S      �� .��5T      �� .+�5V   "   �� $��16(�6,   $��Материалы��6:   $��
10,10,10,0q�6K   �� 5W   "   -   5         ��Name$ SelectMaterial��5W   )   $%��Выбрать материал��6A   $��10q�6\   
�������$
 Hand��6�   �� 5Y   "   $��10q�6,   #��[ 68   $��Stretch=�6�   $��Disabled=�6�   $��Stretch=�6�   $��Stretch=�6  ��6p   �� *SpendedMaterials+��5Z   &   �� 5[   *   " ��67   .R�5\   .   �  5]   2   �� 5^   6   $	��60* �6G   �� 5_   6   $	��20* �6G   �� 5`   6   $	��20* �6G   .+�5b   2   �� $��Center=�6R   $
��Wrap=�6m   $��14(�6�   $
��10,5q�6�   ��6<   �� *Name+6�   >  8MaterialDesignExtensions.Controls.OversizedNumberSpinner  5c   2   
�������$��1��6`   $��Center=�6�   
   Min$ 1��6�   
   Max$	 100��6�   $��Center=�6�   $	��0,5q�6     Value 6p   �� *Amount+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6  '  !MaterialDesignThemes.Wpf.PackIcon  5d   2   -   5           Kind$ Close=�5d   J   ���#EF5350$��2��6l   $��Center=�6|   
������ $��30��6�   $��30��6�   $��Right=�6�   $
��10,5q�6  5e   /   5f   +   5h   #   5i      5j      5k      5l      �� 5m      $��Bottom=�6   $��0,0,0,60q�68   .+�5n      �� $%��Полная стоимость��6    $��Center=�68   $��16(�6U   �� 5o      $��20(�6R   $��Center=�6`   ��6    �� *
TotalPrice+ �� StringFormat$ {0} ₽��6`   5p      �� 5q      -   5        $ FinishOrder��5q      $#��Завершить заказ��6.   $��Bottom=�6H   $��15q�6c   $��Center=�6o   $	��200��6�   
�������6�   5r      5s      5t      5u      