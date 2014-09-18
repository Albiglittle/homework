//�������� ���� 171 ������ ������
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <locale.h>
#include <string.h> 

#pragma warning(disable:4996)

struct Tree
{
	int value;
	Tree *left;
	Tree *right; // ��������� �� ����� � ������ ���������
};

void del(Tree **, int);
Tree *createTree(Tree *);
void add(Tree *);
void searchNode(Tree *, int);
void printTree(Tree *, int);
void inorder(struct Tree *);
void clean(Tree *);

void main(void)
{
	setlocale(LC_ALL, "Russian");
	Tree *tree;
	tree = NULL; // ����� ����� ������
	system("cls");
	int st = 0;
	int value = 0;
	do
	{
		while (1)
		{
			puts("��� ��������: \n 1 - ������� ������");
			puts(" 2 - ������ ������ � ������������ �������");
			puts(" 3 - ����� � ���� ������������� ������");
			puts(" 4 - ���������� ��������� � ������");
			puts(" 5 - �������� ������ �������� �� ������");
			puts(" 6 - ����� ��������");
			puts(" 7 - �������� ������");
			puts(" 8 - �������� ������ � ����� �� ���������");
			fflush(stdin);
			switch (getch())
			{
			case '1':
				tree = createTree(tree);
				break;
			case '2':
				inorder(tree);
				getch();
				break;
			case '3':
				printTree(tree, 0);
				getch();
				break;
			case '4':
				add(tree);
				break;
			case '5':
				printf("\n ������� ����� ��� ��������:\n");
				fflush(stdin);
				scanf("%d", &st);
				del(&tree, st);
				break;
			case '6':
				printf("������� �������� �������� ��������:\n");
				fflush(stdin);
				scanf("%d", &value);
				searchNode(tree, value);
				getch();
				break;
			case '7':
				if (tree != NULL)
				{
					clean(tree);
					tree = NULL;
				}
				printf("������ �������.\n");
				getch();
				break;
			case '8':
				if (tree != NULL)
				{
					clean(tree);
				}
				printf("����� ��������!\n");
				return;
			}
			system("cls");
		}
		printf("��������� - r/n");
		fflush(stdin);
	} while (getch() == 'r');
}

Tree *createTree(Tree *tree)  // �������� ������
{
	if (tree)
	{
		puts("�������� ������ ��� �������.");
		getch();
		return (tree);
	}
	if (!(tree = (Tree*) calloc(1, sizeof(Tree))))
	{
		puts("��� ��������� ������!");
		getch();
		return NULL;
	}
	puts("������� ���������� � ������ ������: ");
	fflush(stdin);
	scanf("%d", &tree->value);
	return tree;
}

void add(Tree *tree)  // ������� ���������� �����
{
	Tree *tree1, *tree2;
	int resultOfComparison; // ��������� ��������� ���� �����
	int ind;
	int valueOfNode = 0;
	if (!tree)
	{
		puts("��� ����� ������! \n");
		getch();
		return;
	}
	do
	{
		puts("������� ���������� � ��������� ���� ������ (0 - �����)");
		fflush(stdin);
		scanf("%d", &valueOfNode);
		if (!valueOfNode) return; // ����� � ������� main
		tree1 = tree;
		ind = 0; // 1 - ������� ������ �� ����� ������
		do
		{
			if (!(resultOfComparison = valueOfNode - tree1->value))
			{
				ind = 1; // ��� ������ �� �����
			}
			else if (resultOfComparison < 0) // �������� ������ ������ ������ � ������������� ����
			{
				if (tree1->left)
				{
					tree1 = tree1->left; // ��������� ����� ���� ������
				}
				else
				{
					ind = 1; // ����� �� �����
				}
			}
			else if (tree1->right) // �������� ������ ������ ������ � ������������� ����
			{
				tree1 = tree1->right; // ��������� ����� ���� ������
			}
			else
			{
				ind = 1; // ����� �� �����
			}
		} while (ind == 0);
		if (resultOfComparison) // �� ������ ���� � ����������� �����������
		{
			if (!(tree2 = (struct Tree *) calloc(1, sizeof(struct Tree))))
			{
				puts("��� ��������� ������!");
				return;
			}
			if (resultOfComparison < 0)
			{
				tree1->left = tree2; // ������ � tree1 ������
			}
			else
			{
				tree1->right = tree2; // ������ � tree1 �������
			}
			tree2->value = valueOfNode; // ���������� ������ ���� tree2
		}
	} while (1); // ����� �������, ����� �� ����� �� return
}

void del(Tree **tree, int valueOfNode)  // ������� �������� ���� ������
{
	if (!*tree)
	{
		printf("\n ������ ������ ��� ������� �����������!\n");
		return;
	}
	if (valueOfNode < (*tree)->value)
	{
		del(&(*tree)->left, valueOfNode);
	}
	else if (valueOfNode >(*tree)->value)
	{
		del(&(*tree)->right, valueOfNode);
	}
	else
	{
		Tree *lt, *rt;
		lt = (*tree)->left;
		rt = (*tree)->right;
		free(*tree);
		*tree = rt;
		while (*tree)
		{
			tree = &(*tree)->left;
		}
		*tree = lt;
	}
}

void searchNode(Tree *tree, int value)
{
	if ((value < tree->value) && (tree->left != nullptr))
	{
		searchNode(tree->left, value);
	}
	else if ((value > tree->value) && (tree->right != nullptr))
	{
		searchNode(tree->right, value);
	}
	else if (tree->value == value)
	{
		printf("������� ���� ������� ����������.\n");
	}
	else
	{
		printf("������� ������������.\n");
	}
}

void printTree(Tree *tree1, int level)
{
	if (tree1)							//���� tree �� ����� ����
	{
		printTree(tree1->right, level + 1);
		for (int i = 0; i < level; i++) //����������� ������
		{
			printf("        ");
		}
		printf("   ____\n");
		for (int i = 0; i < level; i++)
		{
			printf("        ");
		}
		printf("->| %2d |\n", tree1->value);
		for (int i = 0; i < level; i++)
		{
			printf("        ");

		}
		printf("  |____|\n");
		printTree(tree1->left, level + 1);
	}
}

void clean(Tree *tree)
{
	if ((tree->left == nullptr) & (tree->right == nullptr))
	{
		free(tree);
		return;
	}
	if (tree->left != nullptr)
	{
		clean(tree->left);
	}
	if (tree->right != nullptr)
	{
		clean(tree->right);
	}
	//free(tree);
}

void inorder(struct Tree *root)
{
	if (!root) return;
	inorder(root->left);
	if (root->value)
	{
		printf("%d ", root->value);
	}
	inorder(root->right);
}