   M S B A M L   `   `   `  ���� X  TWPF Company Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:WPF_Company_Management_SystemWPF_Company_Management_System  .    (WPF_Company_Management_System.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     =local+clr-namespace:WPF_Company_Management_System       � Title$  Management System��$	��450��$	��800��$	��550��$	��900�����#021526.���  � ColumnDefinitions �� $	��200���� $��* �.+��� $��0��
�������$��1q�$��1q� �� CornerRadius$ 2��._�� $��	5,20,5,10q� � RowDefinitions �� $��* ��� $
��Auto �.+��� $��0��$	��Top=�.+��� -   $��HomeBtn��$��2q�$��35�����#AD62AA
�������$
��Bold"�.��Home�� -   $��ProductsBtn��$��2q�$��35�����#AD62AA
�������$
��Bold"�.��
Products�� -   $��EmployeesBtn��$��2q�$��35�����#AD62AA
�������$
��Bold"�.��	Employees�� -   $��CustomersBtn��$��2q�$��35�����#AD62AA
�������$
��Bold"�.��	Customers�� $��1��$��.\Resources\Logo.png��$	��100��$��Bottom=��� $��1��
�������$��1q�$��1q�$ 2��._�� .+�� -   $��	HomePanel��$y�Visible=�$��stretch=� �� $
��auto ��� $��* �.+��� $��0��
�������$��Times New Roman)�$��30(�$��Center=�$	��Top=�$��0,20,0,0q�.��Company Management System�� $��1��$��Resources/Banner.png��$	��200��$��Center=��� -   $��ProductsPanel��$y�	Collapsed=�.+��� 
�������$��Times New Roman)�$��30(�$��Center=�$	��Top=�$��0,0,0,30q�.��
Products&   System.Windows.Controls.DataGrid  -   $��ProductsDataGrid��   AutoGenerateColumns$
 True��$��Stretch=�$
��20,0q�]� $��0,20,0,0q�.+��� -   $��ProductsRepresentation��$��DemiBold"�$��13(�
�������$
��20,0q�.��
Product:�� -	   $��ProductsDetails��$
��Wrap=�
�������$	��300�� �� Padding$ 0,8,0,0q��� -
   $��ProductsImage��$	��100��$	��100��$	��180��$	��150��$��	10,0,20,0q�$��Right=�]� $	��300��$��Center=�$��0,10,0,0q�.+��� -   $��ProductAddBtn��$��90��$��5q�$��35��$
��Bold"�
���"�"�.��	Add New�� -   $��ProductEditBtn��$��90��$��5q�$��35��$
��Bold"�
����d�.��Edit�� -   $��ProductDeleteBtn��$��90��$��5q�$��35��$
��Bold"�
��� E��.��Delete�� -   $��EmployeesPanel��$y�	Collapsed=�$��20q�.+��� 
�������$��Times New Roman)�$��30(�$��Center=�$	��Top=�$��0,0,0,50q�.��	Employees  -   $��EmployeesDataGrid��$
 True��]� $
��0,20q�.+��� -   $��EmployeeDetailsLabel��$��DemiBold"�$��13(�
�������.��	Employee:�� -   $��EmployeeDetailsTextBlock��$
��Wrap=�
�������$	��300��$ 0,8,0,0q��� -   $��EmployeeImage��$	��100��$	��100��$	��180��$	��150��$��	10,0,20,0q�$��Right=�]� $	��300��$��Center=�$��0,10,0,0q�.+��� -   $��EmployeeAddBtn��$��90��$��5q�$��35��$
��Bold"�
���"�"�.��	Add New�� -   $��EmployeeEditBtn��$��90��$��5q�$��35��$
��Bold"�
����d�.��Edit�� -   $��EmployeeDeleteBtn��$��90��$��5q�$��35��$
��Bold"�
��� E��.��Delete�� -   $��CustomersPanel��$y�	Collapsed=�$��20q�.+��� 
�������$��Times New Roman)�$��30(�$��Center=�$	��Top=�$��0,0,0,50q�.��	Customers  -   $��CustomersDataGrid��$��Stretch=�]� $��	0,10,0,10q�.+��� -   $��CustomersDetailsLabel��$��DemiBold"�$��13(�
�������.��	Customer:�� -   $��CustomerDetailsTextBlock��$
��Wrap=�
�������$	��300��$ 0,8,0,0q��� -   $��CustomerImage��$	��100��$	��100��$	��180��$	��150��$��	10,0,20,0q�$��Right=�]� $��0,10,0,0q�$��Center=�.+��� -   $��AddNewCustomerBtn��$��90��$��5q�$��35��$
��Bold"�
���"�"�.��	Add New�� -   $��CustomerEditBtn��$��90��$��5q�$��35��$
��Bold"�
����d�.��Edit�� -   $��CustomerDeleteBtn��$��90��$��5q�$��35��$
��Bold"�
��� E��.��Delete