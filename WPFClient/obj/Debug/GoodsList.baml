   M S B A M L   `   `   `  ����  GUI    GUI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  
GOOD LIST ��5   	   $	��600��5      $��602.612��6    � WindowStartupLocation$ CenterScreen=�6    .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5	      6   �� 5
      $��50 �6   6*    � ColumnDefinitions 5   
   .+�5   
   �� $��0��6   $��0��6%    �� Orientation$ 
Horizontal=�62   $
��Left=�6K   .+�5      �� -   5        $��b_Add��5   >   $	��Add��6   $��16(�6$   $	��600��62   $��30��6K   $	��Top=�6W   6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��dg_goods��5   0   $��0��6   $��1��6#      SelectionMode$ Single=�6@   �� 5   
   $��0��6   $��2��6%   $ 
Horizontal=�62   $��Right=�6K   .+�5      �� -   5        $��b_Edit��5   ?   $
��Edit��6   $��16(�6%   $	��300��63   6d   �� 5      -   5        $��b_Delete��5   A   $��Delete��6   $��16(�6'   $	��300��65   6j   5      5      5      