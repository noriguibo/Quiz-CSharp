   M S B A M L   `   `   `  ���� C  ?Quiz ALG, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Quiz_ALGQuiz_ALG      Quiz_ALG.EditQuiz   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:Quiz_ALG       � Title$  Editar Quiz��$	��560��$
��1000�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�����  �� ImageSource$&  /Resources/Images/background.png�� j� Stretch$ UniformToFill=� � 	Resources    StandardBorderBrush �� Color  StandardBackgroundBrush  HoverBorderBrush  SelectedBackgroundBrush  SelectedForegroundBrush  DisabledForegroundBrush  
GlyphBrush  NormalBrush  NormalBorderBrush 	 HorizontalNormalBrush 
 HorizontalNormalBorderBrush  ListBoxBackgroundBrush �� 
StartPoint	 �� EndPoint
 � Color � Offset  StandardBrush  PressedBrush  ScrollBarLineButton �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Path �� RelativeSource �� Triggers P� Property P� Value �� 
TargetName  ScrollBarPageButton  ScrollBarThumb  VerticalScrollBar � RowDefinitions ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton  HorizontalScrollBar � ColumnDefinitions �� Triggers  FavsScrollViewer �� VerticalOffset � Value �� ScrollableHeight  � Maximum! �� ViewportHeight" �� ViewportSize*# �� #ComputedVerticalScrollBarVisibility$ �� Orientation% �� HorizontalOffset& �� ScrollableWidth' �� ViewportWidth,( �� %ComputedHorizontalScrollBarVisibility  FocusVisual) �� StrokeDashArray* J� SnapsToDevicePixels  Button.Static.Background  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground  TitleButton+ ��Name, ��Name  	RedButton- �� ContentStringFormat. �� ContentStringFormat   PurpleButton ! OrangeButton��%�  &	        &	      &	 $     &	 4     &	 D     &	 U     &	 e     &	 u     &	 �     &		 �     &	
 �     &	 �     &	 0    &	 �    &	     7  7  7  7  7  &	 �    &	 �    &	 �    7  7  7  7 	 7 
 7  7  &	 O    7  7  7  7  7  7  7  '�� 	    7  7  &	 W
    &	 �    &	 �    &	 �    &	     &	 '    &	 <    &	 Q    &	 f    &	 {    &	 �    &	 �    7  7  7  &	 �    7  7  7  &	  J    7  7  7  &	! �    7  7  7  '�� �    �� $ Black���� $ #bbf6e9���� $
 #DDD���� $
 Gray���� $ White���� $
 #888���� $
 Gray���� $
 Gray���� $ Black���� $
 Gray���� $ Black���� $	 0,0&�$	 1,0.001&���� � $
 White��$	 0.0Q�� $
 White��$	 0.6Q�� $
 #DDDDDD��$	 1.2Q��� $	 0,0&�$		 0,1&���� � $

 #FFF��$	 0.0Q�� $

 #CCC��$	 1.0Q��� $	 0,0&�$		 0,1&���� � $

 #BBB��$	 0.0Q�� $

 #EEE��$	 0.1Q�� $

 #EEE��$	 0.9Q�� $

 #FFF��$	 1.0Q��� " ��.���  � y�$ Hidden=���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true����  � |�$ false����  � �� �� " ��.R��� $��Border��$��1q�$ 2��8��  8�� $��1q�._�F� $��Center=�$��Center=�8�� ���� $ Content� �� *TemplatedParent+ P�  � ��$
 true��. ��� $ Border��8   � ��P�  � {�$ false��. ��� 8   � ���� " ��.���  � y�$ Hidden=���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true����  � ��$ false����  � |�$ false����  � �� �� " ��.R��� 
���   ��� " n�.���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true����  � ��$ false����  � |�$ false����  � �� �� " n�.R��� $ 4��#��z��#��z��$	��1.5q�$��8��$��8,0,-2,0q��� " ��.R��  �� $��0���� $��0.00001* ��� $��0��.+��� $��3��$ 2��
������ �� $��0��8��  $��18��$��ScrollBar.LineUpCommand��$��M 0 4 L 8 4 L 4 0 Z��]� $��
PART_Track��$��1��$
��true�� �� 8�� $��ScrollBar.PageUpCommand�� n� 8�� $��1,0,1,0q�8�� 8��  �� 8�� $��ScrollBar.PageDownCommand���� $��3��8�� $��18��$��ScrollBar.LineDownCommand��$��M 0 0 L 4 4 L 8 0 Z���� " ��.R��  �� $��18���� $��0.00001* ��� $��18��.+��� $��3��$ 2�����#F0F0F0�� $��0��8��  $��18��$��ScrollBar.LineLeftCommand��$��M 4 0 L 4 8 L 0 4 Z��]� $��
PART_Track��$��1��$��False�� �� 8�� $��ScrollBar.PageLeftCommand�� n� 8�� $��0,1,0,1q�8�� 8��  �� 8�� $ ��ScrollBar.PageRightCommand���� $��3��8�� $��18��$ ��ScrollBar.LineRightCommand��$��M 0 0 L 4 4 L 0 8 Z���� " ��.���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true�� P�  �@��Orientation$ 
Horizontal=�. ���  � ��$
 Auto����  � ��$ 18����  � ��8   P�  �@��Orientation$ Vertical=�. ���  � ��$ 18����  � ��$
 Auto����  � ��8  �� " ��.���  �@�OverridesDefaultStyle$
 True����  � �� �� " ��.R��  �� $
��Auto ���  �� �� $
��Auto �.+��� $��1���� $��PART_VerticalScrollBar��# z #  z #" z! #y�z# �� $��PART_HorizontalScrollBar��$$ 
Horizontal=�$��1��$��1��# z% #  z& #" z' #y�z( �� .���  � �� �� .R��� $��2q�$	) 1 2R�#��� ��$
* true��$��1���� $ 	#FFDDDDDD���� $ 	#FF707070���� $ 	#FFBEE6FD���� $ 	#FF3C7FB1���� $ 	#FFC4E5F6���� $ 	#FF2C628B���� $ 	#FFF4F4F4���� $ 	#FFADB2B5���� $ 	#FF838383���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $+ border��#��z��#��z��#��z��$
* true��._��� $, contentPresenter��$|�False��#��z��#��z��$
��True��#* z* #��z�� P�  �@��IsDefaulted$
 true��. ��� $ border�� � ��
 ���� P�  � {�$
 true��. ��� $ border�� � ��
 ���� �� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $+ border��#��z��#��z��#��z��$
* True��._��� $, contentPresenter��#��z��#��z��#. z- $|�False��#��z��#��z��$
��True��#* z* #��z�� P�  �@J�IsMouseOver$
 True��. ��� $ border�� � �� �� $	 0,0&�$		 1,1&�.��� $
 #e2c3cd��$ 1Q�� $
 #fedae6��$ 0Q�P�  �@J�	IsFocused$
 True��. ��� $ border�� � �� �� $	 0,0&�$		 1,1&�.��� $
 #e2c3cd��$ 1Q�� $
 #fedae6��$ 0Q��� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $+ border��#��z��#��z��#��z��$
* True��._��� $, contentPresenter��#��z��#��z��#. z- $|�False��#��z��#��z��$
��True��#* z* #��z�� P�  �@J�IsMouseOver$
 True��. ��� $ border�� � �� �� $	 0,0&�$		 1,1&�.��� $
 #bdb1e2��$ 1Q�� $
 #d6c9ff��$ 0Q�P�  �@J�	IsFocused$
 True��. ��� $ border�� � �� �� $	 0,0&�$		 1,1&�.��� $
 #bdb1e2��$ 1Q�� $
 #d6c9ff��$ 0Q��� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R��� $+ border��#��z��#��z��#��z��$
* True��._��� $, contentPresenter��#��z��#��z��#. z- $|�False��#��z��#��z��$
��True��#* z* #��z�� P�  �@J�IsMouseOver$
 True��. ��� $ border�� � �� �� $	 0,0&�$		 1,1&�.��� $
 #e1cdb9��$ 0Q�� $
 #fde7d0��$ 1Q�P�  �@J�	IsFocused$
 True��. ��� $ border�� � �� �� $	 0,0&�$		 1,1&�.��� $
 #e1cdb9��$ 0Q�� $
 #fde7d0��$ 1Q��� " ��.���  � �� �� " ��.R��� $��border��#��z��#��z��#��z��$
* True��._��� $��PART_ContentHost��$
��Auto=�$��Hidden=�$|�False�� P�  �@J�IsMouseOver$
 True��. ��� $ border�� � ��
 �   �.��� .+��� -   / ��Name$/ lbMainBorder��
���   �$��2q�
������ $��3���� -   $/ 
lbTitleBar��$��	0,0,0,508q�
���   �$��2q����#fde7d0�� -   $/ lbTitle��$��9,8,706,517q�$��DemiBold"�$��Editando Quiz��$��16(�$��Center=�
���   �
���   �$��2q�
��������� -   0 ��Name$0 
btMinimize��#��[ $��	896,6,0,0q�$��0q�$
��Left=�$	��Top=�$��40��$��43��.���� $$��/Resources/Images/minimize.png��$��UniformToFill=�$��36��$��36���� -   $0 btClose��#��[ $��	944,6,0,0q�$��0q�$
��Left=�$	��Top=�$��40��$��43��.���� $!��/Resources/Images/close.png��$��UniformToFill=�$��36��$��36��� -   1 �Name$1 gdQuestionE��$y�Visible=�$��20,21,434,20q�.+��� -   $/ 	lbBorderE��$y�Visible=����#d6c9ff
���   �$��2q�$��	0,43,0,-8q��� -   $/ lbQuestionE�����#d6c9ff
���   �$��2q�$��Center=�$��Center=�$��20,56,20,305q�.���� -	   2 ��Name$2 
stateblock��$y�Visible=�$
��Wrap=�3 �� TextAlignment$3 Center=�4 �� Padding$4 13q�$	��483��$	��108��$��DemiBold"�
���   �$��20(�$��Center=�$	��Top=����� 5 �� ElementName$5 tbStatement��$
 Text��� -
   $0 bt1stAnswerE��#��� ! $y�Visible=�$��14(�$��Center=�$��Center=�$��DemiBold"�
���   ����#fde7d0
���   �$��2q�$��32,226,32,233q�$	��482��$��60��$��60������ $5 	tbAnswer1��$
 Text��� -   $0 bt2ndAnswerE��#��� ! $y�Visible=�$��14(�$��Center=�$��Center=�$��DemiBold"�
���   ����#fde7d0
���   �$��2q�$��32,297,32,162q�$	��482��$��60��$��60������ $5 	tbAnswer2��$
 Text��� -   $0 bt3rdAnswerE��#��� ! $y�Visible=�$��14(�$��Center=�$��Center=�$��DemiBold"�
���   ����#fde7d0
���   �$��2q�$��32,371,32,88q�$	��482��$��60��$��60������ $5 	tbAnswer3��$
 Text��� -   $0 bt4thAnswerE��#��� ! $y�Visible=�$��14(�$��Center=�$��Center=�$��DemiBold"�
���   ����#fde7d0
���   �$��2q�$��32,442,32,17q�$	��482��$��60��$��60������ $5 	tbAnswer4��$
 Text�� -   $1 gdEditField��$��571,21,10,20q�.+��� -   $2 tblQuizName��$��Nome do Quiz:��$��DemiBold"�
���   �$��18(�$��10,40,223,376q��� -   6 ��Name$6 
tbQuizName��$�� ��$��DemiBold"�
���   �
�������
���   �$��2q�$��18(�$��10,63,157,409q��� -   $2 tblQuestion��$��	Questão:��$��DemiBold"�
���   �$��18(�$��10,117,283,309q��� -   7 ��Name$7 
cbQuestion��$��18(�8 �� 
IsEditable$8 False��$��DemiBold"�
���   �
�������
���   �$��2q�$��9,142,246,334q����� .R��� 9 �� Orientation$9 
Horizontal=�.+��� ���� *ID+�� -   $2 tblStatement��$��	Pergunta:��$��DemiBold"�
���   �$��18(�$��10,194,283,233q��� -   $6 tbStatement��$�� ��: �� TextWrapping$
: Wrap=�"; �� VerticalScrollBarVisibility$
; Auto=�$��DemiBold"�
���   �
�������
���   �$��2q�$��18(�$��8,220,18,203q��� -   $2 	tblAnswer��$��Resposta 1:��$��DemiBold"�
���   �$��18(�$��10,323,283,104q��� -   $6 	tbAnswer1��$y�Visible=�$�� ��$��DemiBold"�
���   �
�������
���   �$��2q�$��18(�$��8,349,17,123q��� -   $6 	tbAnswer2��$y�Hidden=�$�� ��$��DemiBold"�
���   �
�������
���   �$��2q�$��18(�$��8,349,17,123q��� -   $6 	tbAnswer3��$y�Hidden=�$�� ��$��DemiBold"�
���   �
�������
���   �$��2q�$��18(�$��8,349,17,123q��� -   $6 	tbAnswer4��$y�Hidden=�$�� ��$��DemiBold"�
���   �
�������
���   �$��2q�$��18(�$��8,349,17,123q��� -   $2 tblCorrectAnswer��$��Resposta Correta:��$��DemiBold"�
���   �$��18(�$��238,117,7,309q��� -   $7 cbCorrectAnswer��$��18(�$��DemiBold"�
���   �
�������
���   �$��2q�$��237,144,18,332q����� .R��� $9 
Horizontal=�.+��� ���� *ID+�� -   $2 tblTimeLimit��$��Tempo Limite:��$��DemiBold"�
���   �$��18(�$��270,39,-25,387q��� -   $7 cbTimeLimit��$��18(�$��DemiBold"�
���   �
�������
���   �$��2q�$��270,64,18,412q����� .R��� $9 
Horizontal=�.+��� ���� *ID+�� -   $0 btReturnQuiz��#���   $y�Visible=�$
��Left=�$��RETORNAR��$��DemiBold"�
���   �$��2q�
���   �$��20(����#d6c9ff$��581,459,0,11q�$	��192���� -   $0 
btSaveQuiz��#���  $y�Visible=�$
��Left=�$��SALVAR��$��DemiBold"�
���   �$��2q�
���   �$��20(����#fedae6$��784,460,0,10q�$	��192��