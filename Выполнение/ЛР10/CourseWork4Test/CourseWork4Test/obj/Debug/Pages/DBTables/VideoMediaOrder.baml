   M S B A M L   `   `   `  ����J  FCourseWork4Test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:CourseWork4Test.Pages.DBTablesCourseWork4Test.Pages.DBTables  5      4    .CourseWork4Test.Pages.DBTables.VideoMediaOrder   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:CourseWork4Test.Pages.DBTables     5      X TXceed.Wpf.Toolkit, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        N� Title$  VideoMediaOrder��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   �� 5      $
��auto �6   6,   .+�5   
   �� $��0��6   $��28(�6   $��10q�6+   .��67   53Таблица поставок - Video media order6]   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGridVMO��5      $��1��6(      CanUserAddRows .  6�   � 5   
   $��2��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��0.5* �6#   .+�5      �� $��0��6   $��Center=�6)   $��25 5 0 0q�6D   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��18(�6   $��	 0 0 10 0q�6*   .��6=   -+Дата заказа (гггг-мм-дд):6X   %  Xceed.Wpf.Toolkit.MaskedTextBox  5      -   5          Name$ tDateTB��5   7   $��18(�6)      Mask$ 
0000-00-00��6H   $	��463��6Z   $��26��6f   5      �� 5       $ 
Horizontal=�6   .+�5!      �� $��18(�6   $��	 0 0 10 0q�6*   .��6=   PNДата предпологаемого прибытия (гггг-мм-дд):6j     5"      -   5        $ tCompletionDateTB��5"   7   $��18(�6)   $ 
0000-00-00��6R   $	��282��6d   $��26��6p   5#      �� 5$      $ 
Horizontal=�6   .+�5%      �� $��18(�6   $��	 0 0 10 0q�6*   .��6=   Поставщик (ID):6N   �� 5&      -   5         ��Name$ 
ProviderTB��5&      $��18(�62   $��Center=�6@   $	��536��6[   5'      �� 5(      $ 
Horizontal=�6   .+�5)      �� $��18(�6   $��	 0 0 10 0q�6*   .��6=   1/Оформлявший сотрудник (ID):6Z   �� 5*      -   5        $ 
EmployeeTB��5*      $��18(�62   $��Center=�6@   $	��415��6[   5+      �� 5,      $ 
Horizontal=�6   .+�5-      �� $��18(�6   $��	 0 0 10 0q�6*   .��6=   97Поставка прибыла (1 - да, 0 - нет):6b   �� 5.      -   5        $ tCompletionTB��5.      $��18(�65   $��Center=�6C   $	��383��6^   5/      50      �� 52      $��1��6   $��10q�6)   .+�53      �� -   5        	 ��Name$	 NewRecordBtn��53      $��18(�6/   $��3q�6=   .��6c   Новая запись6q   �� 54      -   5        $	 DeleteRecordBtn��54      $��18(�62   $��3q�6@   .��6i   Удаление6s   �� 55      -	   5        $	 SaveTableBtn��55      $��18(�6/   $��3q�6=   
 � ToolTip$\
 VСохраняет только выделенный элемент в таблице!��6c   {�.  .��6�   Сохранение6�   �� 56      -
   5        $	 	UpdateBtn��56      $��18(�6,   $��3 3 3 40q�6:   .��6d   -+Принудительно обновить6|   �� 58      -   5        $	 	GoBackBtn��58      $��18(�6D   .��6R   
Назад6Y   59      5;      5<      5=      