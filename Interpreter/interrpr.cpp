#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#pragma warning (disable:4996)

const int Num = 1024;
int *p;
int *vst;
int *dst;
char str[1000][100], command[10], label[1000][100], adress[100];
int data[1024 * 256];


int Push(int i)
{
	if (p > dst)
	{
		return 1;
	}
	*p = i;
	p++;
	return 0;
}

int Pop(void)
{

	if (p - 1 >= vst)
	{
		p--;
	}
	else
	{
		printf("Stack is empty\n");
		return 0;
	}
	return *p;
}

void StackInit()
{
	int * stack = (int*)malloc(Num*sizeof(int));
	if (!stack)
	{
		printf("Not enough memory for stack");
		exit(2);
	}
	p = (int*)stack;


int ReadFile()
{
	int ip = 0;
	FILE *f = fopen("fib.txt", "r");
	if (f == 0)
	{
		exit(1);
	}

	while (feof(f) == 0)
	{
		fgets(str[ip], 100, f);
		ip++;
	}
	fclose(f);
	return ip;
}

void WriteLabel(int strNumber)
{
	int ip = 0, symb = 0;
	for (ip = 0; ip < strNumber; ip++)
	{
		symb = 0;
		while (1)
		{
			if (str[ip][symb] == ':')
			{
				command[symb] = '\0';
				strcpy(label[ip], command);
				break;
			}
			else if ((str[ip][symb] == '\0') || (str[ip][symb] == ' '))
			{
				command[symb] = '\0';
				break;
			}
			command[symb] = str[ip][symb];
			symb += 1;
		}
		command[symb] = '\0';
	}
}

int ReadCommand(int ip)
{
	int symb = 0, k = 0;
	command[0] = '\0';
	while (1)
	{
		if (str[ip][symb] == ':')
		{
			symb += 1;
			k = 0;
			while (1)
			{
				if ((str[ip][symb] == ' ') || (str[ip][symb] == '\n') || (str[ip][symb] == '\0'))
				{
					break;
				}
				command[k] = str[ip][symb];
				symb += 1;
				k += 1;
			}
			command[k] = '\0';
			break;
		}
		else if ((str[ip][symb] == ' ') || (str[ip][symb] == '\n') || (str[ip][symb] == '\0'))
		{
			break;
		}
		command[symb] = str[ip][symb];
		symb += 1;
	}
	return symb;
}

int Jump(int ip, int symb, int strNumber)
{
	int k = 0, h = 0, flag = 0;
	while (1)
	{
		if (str[ip][symb] == '\0')
		{
			break;
		}
		adress[k] = str[ip][symb];
		k += 1;
		symb += 1;
	}
	adress[k - 1] = '\0';
	for (h = 0; h < strNumber; h++)
	{
		if ((strcmp(adress, label[h]) == 0))
		{
			ip = h - 1;
			flag = 1;
			break;
		}
	}
	if (flag == 0)
	{
		printf("Error. Label %s not found", adress);
		exit(1);
	}
	return ip;
}

int ExecuteCommand(int ip, int symb, int strNumber)
{
	int a = 0, b = 0, k = 0, adr = 0, z = 0;
	command[symb] = '\0';
	while (str[ip][symb] == ' ')
	{
		symb += 1;
	}
	////////////////////////////«агрузить на вершину стека константу из data
	if (strcmp(command, "ld") == 0)
	{
		while (!(str[ip][symb] == ' ' || str[ip][symb] == '\0'))
		{
			adress[k] = str[ip][symb];
			k += 1;
			symb += 1;
		}
		adr = atof(adress);
		Push(data[adr]);
	}
	else
		////////////////////////////«агрузить константу на вершину стека
		if (strcmp(command, "ldc") == 0)
		{
		while (!(str[ip][symb] == ' ' || str[ip][symb] == '\0'))
		{
			adress[k] = str[ip][symb];
			k += 1;
			symb += 1;
		}
		Push(atof(adress));
		}
		else
			////////////////////////////«агрузить константу в Data с вершины стека
			if (strcmp(command, "st") == 0)
			{
		while (!(str[ip][symb] == ' ' || str[ip][symb] == '\0'))
		{
			adress[k] = str[ip][symb];
			k += 1;
			symb += 1;
		}
		adr = atof(adress);
		data[adr] = Pop();
			}
			else
				////////////////////////////—ложение двух чисел на вершине стека
				if (strcmp(command, "add") == 0)
				{
		a = Pop();
		b = Pop();
		a = a + b;
		Push(a);
				}
				else
					////////////////////////////¬ычитание двух чисел на вершине стека
					if (strcmp(command, "sub") == 0)
					{
		a = Pop();
		b = Pop();
		Push(a - b);
					}
					else
						///////////////////////////”множение двух чисел на вершине стека
						if (strcmp(command, "mul") == 0)
						{
		a = Pop();
		b = Pop();
		Push(a*b);
						}
						else
							///////////////////////////÷ела€ часть от делени€ двух чисел на вершине стека
							if (strcmp(command, "div") == 0)
							{
		a = Pop();
		b = Pop();
		Push((int)(a / b));
							}
							else
								///////////////////////////ќстаток от делени€ нацело на вершине стека
								if (strcmp(command, "mod") == 0)
								{
		a = Pop();
		b = Pop();
		Push(a % b);
								}
								else
									///////////////////////////јбсолютна€ часть числа от вершины стека
									if (strcmp(command, "abs") == 0)
									{
		a = Pop();
		if (a >= 0)
		{
			Push(a);
		}
		else
		{
			Push(-a);
		}
									}
									else
										///////////////////////////—равнение двух чисел на вершине стека
										if (strcmp(command, "cmp") == 0)
										{
		a = Pop();
		b = Pop();
		if (a > b)
		{
			Push(1);
		}
		else
			if (a < b)
			{
			Push(-1);
			}
			else
				if (a == b)
				{
			Push(0);
				}
										}
										else
											////////////////////////////Ѕезусловный переход по метке
											if (strcmp(command, "jmp") == 0)
											{
		ip = Jump(ip, symb, strNumber);
											}
											else
												////////////////////////////ѕереход по метке если на верине стека 0
												if (strcmp(command, "jz") == 0)
												{
		z = Pop();
		Push(z);
		if (z == 0)
		{
			ip = Jump(ip, symb, strNumber);
		}
												}
												else
													/////////////////////////////ѕереход по метке если на верине стека != 0
													if (strcmp(command, "jnz") == 0)
													{
		z = Pop();
		Push(z);
		if (z != 0)
		{
			ip = Jump(ip, symb, strNumber);
		}
													}
													else
														////////////////////////////ѕереход по метке если на верине стека > 0
														if (strcmp(command, "jg") == 0)
														{
		z = Pop();
		Push(z);
		if (z > 0)
		{
			ip = Jump(ip, symb, strNumber);
		}
														}
														else
															/////////////////////////////ѕереход по метке если на верине стека <0
															if (strcmp(command, "jl") == 0)
															{
		z = Pop();
		Push(z);
		if (z < 0)
		{
			ip = Jump(ip, symb, strNumber);
		}
															}
															else
																/////////////////////////////”даление последнего элемента на стеке
																if (strcmp(command, "std") == 0)
																{
		a = Pop();
																}
																else
																	if (strcmp(command, "print") == 0){ printf("%d %d %d\n", data[0], data[1], data[2]); }
	return ip;
}


int main()
{
	int  ip = 0, symb = 0, strNumber = 0;
	int * const stack = (int*)malloc(Num*sizeof(int));

	StackInit();
	strNumber = ReadFile();
	WriteLabel(strNumber);
	do
	{
		symb = ReadCommand(ip);
		ip = ExecuteCommand(ip, symb, strNumber);
		ip++;
	} while (strcmp(command, "ret") != 0);
	printf("data:%d", data[3]);
	return 0;
}