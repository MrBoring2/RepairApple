   M S B A M L   `   `   `  ����F  BAppleRepair, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:AppleRepair.Views.WindowsAppleRepair.Views.Windows  5   	   ,    &AppleRepair.Views.Windows.ClientWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:AppleRepair.Views.Windows     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	     � WindowStartupLocation$  CenterScreen=�5       � Title$> 8APPLE СЕРВИС | Добавление клиента��5
   	   $	��450��63   $	��429��6@    � Icon$  /Resources/Images/logo.png��6L   .��5      � .+�5   
   �� $��20,20,20,20q�6    �� CornerRadius$ 30��6&   ���#9E9E9E$��1q�6N   ._�5      �  � ColumnDefinitions 5      �� 5      .+�5      �� $��0��6   $��0,0,0,0q�6-   .+�5      � .+�5      �� $��14(�6$   $��ФИО��62   $��
15,10,15,0q�6=   �� 5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$* $Введите ФИО клиента��6#   $��14(�6X   $	��Top=�6f   $��1��6�   $��
15,25,15,0q�6�    � Cursor$ IBeam��6�   ��6~   �� *
FullName+6�   5      � 5      .+�5      �� $��14(�6$   $!��Номер телефона��62   $��
15,10,15,0q�6H   �� 5      $2 ,Введите телефон клиента��6#   $��14(�6\   $	��Top=�6j   $��1��6�   $��
15,25,15,0q�6�   $ IBeam��6�   ��6�   �� *PhoneNumber+6�   5      � 5      .+�5      �� $��14(�6$   $��
Почта��62   $��
15,10,15,0q�6?   �� 5      $. (Введите почту клиента��6#   $��14(�6Z   $	��Top=�6h   $��1��6�   $��
15,25,15,0q�6�   $ IBeam��6�   ��6�   �� *Email+6�   5      5      �� 5!      -   5         ��Name$
 Save��5!      $��Сохранить��6'   $��Bottom=�6;   $��
15,0,15,15q�6V   $��Center=�6j   $	��200��6�   
�������$
 Hand��6�   5"      5#      5$      5%      