   M S B A M L   `   `   `  ����F  BAppleRepair, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AppleRepair.Views.WindowsAppleRepair.Views.Windows  5   	   .    (AppleRepair.Views.Windows.DeliveryWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:AppleRepair.Views.Windows     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      _ [MaterialDesignExtensions, Version=3.3.0.0, Culture=neutral, PublicKeyToken=c5ebccebe084d64fHmde>https://spiegelp.github.io/MaterialDesignExtensions/winfx/xaml  5
   
     � WindowStartupLocation$  CenterScreen=�5	       � Title$@ :APPLE СЕРВИС | Поставка материалов��5   	   $	��450��64   $	��800��6A    � Icon$6 0/AppleRepair;component/Resources/Images/logo.png��6M   .��5      � .+�5   
   �� $��20,20,20,20q�6    �� CornerRadius$ 30��6&   ���#9E9E9E$��1q�6N   ._�5      �  � ColumnDefinitions 5      �� 5      $	��61* �6'   �� 5      $
��137* �6'   .+�5      �� .+�5      �� $��14(�6    $��Поставщик��6.   $��	15,15,0,5q�6?   �� 5      $��14(�6   $
��15,0q�6y    �� DisplayMemberPath$
 Name��6�   ��6-   �� *	Suppliers+ �� SelectedItem 6O   �� *SelectedSupplier+6�   5      �� 5      $��Bottom=�6   $��15,10q�68   .+�5      �� $��16(�6\   $	��0,5q�6j   ��6    �� *
TotalPrice+ �� StringFormat$  Стоимость: {0}₽��6j   �� 5      -   5         ��Name$ delivery��5      $��Заказать��6/   
�������6U   5      �� 5      $��1��6   .+�5      �� $��14(�6    $��Материалы��6.   $��	15,15,0,5q�6?   �� 5       -   5        $ Select��5       $��Выбрать��6-   $
��15,0q�6?   $	��200��6M   $
��Left=�6Y   
�������6�   5!      �� 5"      $��1��6   $��
15,85,15,5q�6/   $
��Auto=�6C   .��5#      � .+�5$      �� $��10q�6$      listViewItemStyle#��[  60   $��Stretch=�6�   $��Disabled=�6�   $��Stretch=�6�   $��Stretch=�6  ��6h   �� *SelectedMaterials+��5%      �� 5&   "   	 �� DataType"	 ��6/   .R�5'   &   �  5(   *   �� 5)   .   $	��60* �6?   �� 5*   .   $	��20* �6?   �� 5+   .   $	��20* �6?   �� 5,   .   $	��20* �6?   .+�5.   *   �� $��Center=�6J   $
��Wrap=�6e   $��14(�6y   $
��10,5q�6�   ��64   �� *Name+6�   �� 5/   *   $��1��6e   $��Center=�6u   $
��Wrap=�6�   $��14(�6�   $
��10,5q�6�   ��64   �� *
TotalPrice+$ {0}₽��6�   >  8MaterialDesignExtensions.Controls.OversizedNumberSpinner  50   *   
�������$��2��6X   $��Center=�6�   

   Min$
 1��6�   
   Max$	 100��6�   $��Center=�6�   $	��0,5q�6�      Value 6h   �� *Amount+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   '  !MaterialDesignThemes.Wpf.PackIcon  51   *   -   5           Kind$ Close=�51   B   ���#EF5350$��3��6d   $��Center=�6t   
������ $��30��6�   $��30��6�   $��Right=�6�   $
��10,5q�6�   52   '   53   #   55      56      57      58      59      5:      5;      