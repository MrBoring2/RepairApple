   M S B A M L   `   `   `  ����F  BAppleRepair, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AppleRepair.Views.WindowsAppleRepair.Views.Windows  5   	   +    %AppleRepair.Views.Windows.OrderWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:AppleRepair.Views.Windows     5   	   _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fHmde>https://spiegelp.github.io/MaterialDesignExtensions/winfx/xaml  5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � WindowStartupLocation$  CenterScreen=�5       � 
ResizeMode$ NoResize=�5	         MaterialDesignBody#���   5
        MaterialDesignPaper#���  5   	    � Title$8 2APPLE СЕРВИС | Создание заказа��5   	   $	��580��60   $
��1000��6=    � Icon$  /Resources/Images/logo.png��6J   ��5   	   :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��5      �  � ColumnDefinitions 5   
   �� 5      .+�5   
   �� $��20,20,20,20q�6    �� CornerRadius$ 30��6&   ���#9E9E9E$��1q�6N   ._�5      �  5      �� 5      $
��276* �6'   �� 5      $
��203* �6'   .+�5      �� $��0��6   .+�5      �� $��14(�6    $��Клиент��6.   $��
15,25,15,0q�6<   � 5       5       �� 5!      $
��450* �6/   �� 5"      $	��100 �6/   .+�5$      �� $��14(�6D   $	��Top=�6R    �� 
IsReadOnly . $��1��6�   $��	15,5,15,0q�6�   {�6"   �� *IsElEnabled+��6j   �� *SelectedClient.FullName+6�   �� 5%      -   5         ��Name$ Select��5%   E   $��1��6U   $��5q�6e   $��Выбрать��6p   
�������y�6!   �� *IsVisibility+6�   5&      �� 5(      $��14(�6    $#��Модель телефона��6.   $��
15,25,15,0q�6E   � 5)       5*      �� 5+      $
��450* �6/   �� 5,      $	��110 �6/   .+�5.      �� $��14(�6E   $��Stretch=�6S   $��15,5,0,0q�6�   {�6#   �� *IsElEnabled+��6x   �� *Models+ �� SelectedItem 6�   �� *SelectedModel+��5/      �� 50   "   	 �� DataType"	 ��6/   .R�51   &   � $��Stretch=�6+   .+�52   *   �� $��15(�6O   ��64   �� *	ModelName+6O   �� 53   *   $��15(�6P   $��Right=�6^   ��64   �� *
Color.Name+6^   54   '   55   #   57      58      �� 5:      $��14(�6    $O��IОжидаемые дата и время окончания заказа��6.   $��
15,25,15,0q�6]   � 5;       5<      �� 5=      $
��100* �6/   �� 5>      $
��100* �6/   .+�5@      (  "System.Windows.Controls.DatePicker  $��14(�6G   $��	15,5,15,5q�6U   {�6%   �� *IsElEnabled+
   SelectedDate
 6h   �� *Date+)  #MaterialDesignThemes.Wpf.TimePicker  5A      $��1��64   $��14(�6f   $��	15,5,15,5q�6t   {�6D   �� *IsElEnabled+   SelectedTime 6�   �� *Time+5B      �� 5D      .+�5E      �� $��14(�6$   $'��!Описание проблемы��62   $��15,0,5,0q�6K   �� 5F      -   5         ��Name$ descriptionText��5F   �   $��14(�6�    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6�   $��	15,0,15,0q�6�    � Cursor$ IBeam��6�   {�6"   �� *IsElEnabled+��6D   �� *Description+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5G      5H      � 5I      $��1��6   
������ .+�5K      #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 20Q�6*   $��15q�6C   ���	#FFF9F9F9+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�6f      ShadowEdges$	 All=�6�   .��5L      �� .��5M      �� .+�5O   "   �� $��14(�6,   $��Услуга��6:   $��
10,10,10,0q�6H   �� 5P   "   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$# Выберите услугу��6O   $��
10,0,10,10q�6�   $��16(�6�   y�6+   �� *IsVisibility+��6�   �� *
Services+ 6�   �� *SelectedService+�� 5R   "   $��10q�6M     listViewItemStyle#��[ 6Y   $��Stretch=�6�   $��Disabled=�6  $��Stretch=�6>  $��Stretch=�6\  {�6+   �� *IsElEnabled+��6�   �� *SelectedServices+ 6�   �� *SelectedSerivce+��5S   &   �� 5T   *   "	 ��67   .R�5U   .   � .+�5V   2   �� $��Center=�6M   $��14(�6h   $
��Wrap=�6v   $
��10,5q�6�   ��6<   �� 6�   '  !MaterialDesignThemes.Wpf.PackIcon  5W   2   -   5           Kind$ Close=�5W   J   ���#EF5350
������ $��30��6�   $��30��6�   $��Right=�6�   $
��10,5q�6�   $��Center=�6�   5X   /   5Y   +   5[   #   5\      5]      5^      5_      �� 5`      -   5        $
 Save��5`   =   $��Сохранить��6K   $��Bottom=�6_   $��15q�6z   $��Center=�6�   $	��200��6�   
�������$
 Hand��6�   y�6   �� *IsVisibility+6�   5a      5b      5c      5d      