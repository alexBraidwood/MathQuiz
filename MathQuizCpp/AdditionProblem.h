#pragma once

class AdditionProblem
{
public:
	AdditionProblem(std::vector<int>& numbers); 
	AdditionProblem(int* numbers, int len);
	std::vector<int> getNumbers();
	LPCWSTR getEquation();
	bool isSolution(float answer);

private:
	std::vector<int> numbers;
	int solution;
};

