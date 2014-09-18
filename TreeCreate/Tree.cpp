//Молчанов Артём 171 группа Дерево
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
	Tree *right; // указатели на левое и правое поддерево
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
	tree = NULL; // адрес корня дерева
	system("cls");
	int st = 0;
	int value = 0;
	do
	{
		while (1)
		{
			puts("Вид операции: \n 1 - Создать дерево");
			puts(" 2 - Обойти дерево в симметричном порядке");
			puts(" 3 - Вывод в виде перевернутого дерева");
			puts(" 4 - Добавление элементов в дерево");
			puts(" 5 - Удаление любого элемента из дерева");
			puts(" 6 - Поиск элемента");
			puts(" 7 - Удаление дерева");
			puts(" 8 - Удаление дерева и выход из программы");
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
				printf("\n Введите число для удаления:\n");
				fflush(stdin);
				scanf("%d", &st);
				del(&tree, st);
				break;
			case '6':
				printf("Введите значение искомого элемента:\n");
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
				printf("Дерево очищено.\n");
				getch();
				break;
			case '8':
				if (tree != NULL)
				{
					clean(tree);
				}
				printf("Всего хорошего!\n");
				return;
			}
			system("cls");
		}
		printf("Повторить - r/n");
		fflush(stdin);
	} while (getch() == 'r');
}

Tree *createTree(Tree *tree)  // создание дерева
{
	if (tree)
	{
		puts("Бинарное дерево уже создано.");
		getch();
		return (tree);
	}
	if (!(tree = (Tree*) calloc(1, sizeof(Tree))))
	{
		puts("Нет свободной памяти!");
		getch();
		return NULL;
	}
	puts("Введите информацию в корень дерева: ");
	fflush(stdin);
	scanf("%d", &tree->value);
	return tree;
}

void add(Tree *tree)  // функция добавления узлов
{
	Tree *tree1, *tree2;
	int resultOfComparison; // результат сравнения двух строк
	int ind;
	int valueOfNode = 0;
	if (!tree)
	{
		puts("Нет корня дерева! \n");
		getch();
		return;
	}
	do
	{
		puts("Введите информацию в очередной узел дерева (0 - выход)");
		fflush(stdin);
		scanf("%d", &valueOfNode);
		if (!valueOfNode) return; // выход в функцию main
		tree1 = tree;
		ind = 0; // 1 - признак выхода из цикла поиска
		do
		{
			if (!(resultOfComparison = valueOfNode - tree1->value))
			{
				ind = 1; // для выхода из цикла
			}
			else if (resultOfComparison < 0) // введённая строка меньше строки в анализируемом узле
			{
				if (tree1->left)
				{
					tree1 = tree1->left; // считываем новый узел дерева
				}
				else
				{
					ind = 1; // выход из цикла
				}
			}
			else if (tree1->right) // введённая строка больше строки в анализируемом узле
			{
				tree1 = tree1->right; // считываем новый узел дерева
			}
			else
			{
				ind = 1; // выход из цикла
			}
		} while (ind == 0);
		if (resultOfComparison) // не найден узел с аналогичной информацией
		{
			if (!(tree2 = (struct Tree *) calloc(1, sizeof(struct Tree))))
			{
				puts("Нет свободной памяти!");
				return;
			}
			if (resultOfComparison < 0)
			{
				tree1->left = tree2; // ссылка в tree1 налево
			}
			else
			{
				tree1->right = tree2; // ссылка в tree1 направо
			}
			tree2->value = valueOfNode; // заполнение нового узла tree2
		}
	} while (1); // любое условие, выход из цикла по return
}

void del(Tree **tree, int valueOfNode)  // функция удаления узла дерева
{
	if (!*tree)
	{
		printf("\n Дерево пустое или элемент отсутствует!\n");
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
		printf("Введёный вами элемент существует.\n");
	}
	else
	{
		printf("Элемент отстутствует.\n");
	}
}

void printTree(Tree *tree1, int level)
{
	if (tree1)							//пока tree не равен нулю
	{
		printTree(tree1->right, level + 1);
		for (int i = 0; i < level; i++) //обозначение уровня
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