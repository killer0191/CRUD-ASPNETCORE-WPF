   M S B A M L   `   `   `  ����H  DAppEscritorio, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:AppEscritorioAppEscritorio  5   	       AppEscritorio.Factura   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:AppEscritorio     5   	     � Title$  Factura��5   	   $	��450��6   $	��800��6&    � 
ResizeMode$ NoResize=�5	   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   o� $��0��6   $��Stretch=�6   $	��Top=�6:   ���#066699.@�5      m� -   5        $��Inicio��5      
�������6Q   m� 5      $��Persona��6   
�������.@�5      m� -   5        $��Agregar��5      ���#f8f8ec
���   �
 � Tag$ Agregar��6j   m� 5      -   5        $��Buscar��5      ���#f8f8ec
���   �$ Buscar��6i   m� 5      -   5        $��Borrar��5      ���#f8f8ec
���   �$ Borrar��6i   5      m� 5      $��Factura��6   
�������.@�5      m� -   5        $��Agregar��5      ���#f8f8ec
���   �$ Agregar��6j   m� 5      -   5        $��Buscar��5      ���#f8f8ec
���   �$ Buscar��6i   5      5      �� 5   
   $��1��6   ���#f8f8ec._�5       �� $��10q�6   $��Center=�6%   $��Center=�6B   .+�5"      �� -   5         ��Name$ Seccion2��5"      $��0,0,0,10q�6/   .+�5#      �� $#��/Resources/buscar_factura.png��6   $	��100��6C   $	��100��6O   �� 5$      $��Buscar Factura��6    $��18(�66   $
��Bold"�6D   $��	0,10,0,10q�6V   $��Center=�6i   �� 5&      -   5         ��Name$ 
RFCTextBox��5&   ]   $	��150��6   $��25��6*   $��0,0,0,10q�66   $	��RFC��6H   $	 RFC��6S   6�   �� 5'      -	   5        $��Buscar��5'      $	��100��6.   $��0,0,0,10q�6:   6L   �� 5(      -
   5         ��Name$ FacturaTextBlock��5(   D   $��	Facturas:��6    $��	0,10,0,10q�61   6D   5)      �� 5,      -   5        $ Seccion1��5,      $��0,0,0,20q�6/   .+�5-      �� $��/Resources/factura.png��6   $	��100��6<   $	��100��6H   �� 5.      $��Agregar Factura��6    $��18(�67   $
��Bold"�6E   $��	0,10,0,10q�6W   �� 50      -   5        $ FechaTextBlock��50   V   $��Fecha: ��6    $��0,0,0,10q�6/   $ FechaTextBlock��6A   6V   �� 51      -   5        $ MontoTextBox��51   a   $	��150��6   $��25��6*   $��0,0,0,10q�66   $��Monto��6H   $ Monto��6U   6�   �� 52      -   5         ��Name$ IdAgregarComboBox��52   =   $	��150��6   $��0,0,0,10q�6+    �� DisplayMemberPath$ Nombre��6X   	 �� SelectedValuePath$	 	IdPersona��6s   �� 53      -   5        $��Agregar��53      $	��100��6/   $��0,0,0,10q�6;   6N   54      56      57      59      5:      