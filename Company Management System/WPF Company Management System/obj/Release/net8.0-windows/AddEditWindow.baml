   M S B A M L   `   `   `  ���� X  TWPF Company Management System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:WPF_Company_Management_SystemWPF_Company_Management_System  1    +WPF_Company_Management_System.AddEditWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     =local+clr-namespace:WPF_Company_Management_System       � Title$  AddEditWindow��$	��600��$	��500��$	��600��$	��500�����#021526.��� $��
20,8,20,20q� � RowDefinitions �� $��50 ��� $��* ��� $
��auto �.+��� -   $��WindowTitle��$��0��
�������$
��Bold"�$��25(�$��Center=�$��Center=�.��Info Change Panel]� -   $��EmplyeeDetails��$��1��$y�Visible=�.+��  � ColumnDefinitions �� $
��auto ��� $��* ��� $��25 �.+��� $��0��$
��Left=�.+��� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��First Name:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��
Last Name:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��	Salary:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��Age:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��Phone Number:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��Email:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��
Address:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��Department:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��Choose Photo:�� $��1��.+��� -   $��EmployeeFirstNameTextBox��$��Center=�$��35��
�������$��0,0,0,10q��� -   $��EmployeeLastNameTextBox��$��Center=�$��35��
�������$��0,0,0,10q��� -   $��EmployeeSalaryTextBox��$��Center=�$��35��
�������$��0,0,0,10q��� -   $��EmployeeAgeTextBox��$��Center=�$��35��
�������$��0,0,0,10q��� -   $ ��EmployeePhoneNumberTextBox��$��Center=�$��35��
�������$��0,0,0,10q��� -   $��EmployeeEmailTextBox��$��Center=�$��35��
�������$��0,0,0,10q��� -	   $��EmployeeAddressTextBox��$��Center=�$��35��
�������$��0,0,0,10q��� -
   $ ��EmployeeDepartmentComboBox��$��Center=�$��35��
�������$��0,0,0,10q�]� $
��Left=�.+��� -   $��EmployeePhotoButton��$
��Left=����� -   $��EmployeeChosenImage��$&�� ./Resources/PlaceholderImage.jpg��$��50���� -   $��EmployeePhotoAddressLabel��
�������$��Center=�$y�Hidden=�.��Photo Address�� $��2��.+��� 
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� 
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� -   $��SalaryValidationWarnLabel��
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� 
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� -   $,��&EmployeePhoneNumberValidationWarnLabel��
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� -   $&�� EmployeeEmailValidationWarnLabel��
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� 
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� 
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� 
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️]� -   $��CustomerDetails��$��1��$y�	Collapsed=�.+��  �� $
��auto ��� $��* ��� $��25 �.+��� $��0��$
��Left=�.+��� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��First Name:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��
Last Name:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��Age:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��Phone Number:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��Email:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��
Address:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��	BuyCount:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��Choose Photo:�� $��1��.+��� -   $��CustomerFirstNameTextBox��$��Center=�$��35��
�������$��0,0,0,10q��� -   $��CustomerLastNameTextBox��$��Center=�$��35��
�������$��0,0,0,10q��� -   $��CustomerAgeTextBox��$��Center=�$��35��
�������$��0,0,0,10q��� -   $ ��CustomerPhoneNumberTextBox��$��Center=�$��35��
�������$��0,0,0,10q��� -   $��CustomerEmailTextBox��$��Center=�$��35��
�������$��0,0,0,10q��� -   $��CustomerAddressTextBox��$��Center=�$��35��
�������$��0,0,0,10q��� -   $��CustomerBuyCountTextBox��$��Center=�$��35��
�������$��0,0,0,10q�]� $
��Left=�.+��� -   $��CustomerPhotoButton��$
��Left=����� -   $��CustomerChosenImage��$&�� ./Resources/PlaceholderImage.jpg��$��50���� -   $��CustomerPhotoAddressLabel��
�������$��Center=�$y�Hidden=�.��Photo Address�� $��2��.+��� 
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� 
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� 
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� -   $,��&CustomerPhoneNumberValidationWarnLabel��
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� -   $&�� CustomerEmailValidationWarnLabel��
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� 
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� 
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� 
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️]� -   $��ProductDetails��$��1��$y�	Collapsed=�.+��  �� $
��auto ��� $��* ��� $��25 �.+��� $��0��$
��Left=�.+��� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��ProductName:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��Description:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��	Category:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��Count:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��Price:�� 
�������$
��Bold"�$��Center=�$
��Left=�$��0,0,0,10q�$��36��.��Choose Photo:�� $��1��.+��� -   $��ProductNameTextBox��$��Center=�$��35��
�������$��0,0,0,10q��� -    $��ProductDescriptionTextBox��$��Center=�$��35��
�������$��0,0,0,10q��� -!   $��ProductCategoryComboBox��$��Center=�$��35��
�������$��0,0,0,10q��� -"   $��ProductCountTextBox��$��Center=�$��35��
�������$��0,0,0,10q��� -#   $��ProductPriceTextBox��$��Center=�$��35��
�������$��0,0,0,10q�]� $
��Left=�.+��� -$   $��ProductPhotoButton��$
��Left=����� -%   $��ProductChosenPhoto��$&�� ./Resources/PlaceholderImage.jpg��$��50���� -&   $��ProductPhotoAddressLabel��
�������$��Center=�$y�Hidden=�.��Photo Address�� $��2��.+��� 
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� 
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� 
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� -'   $��ProductCountWarnLabel��
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� -(   $��ProductPriceWarnLabel��
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� 
���  ��$y�Hidden=�$��0,0,0,10q�$��36��.��⚠️�� -)   $��2��$��50��$��10q�$��
ExtraBlack"�$��16(�$	��100��.��Save