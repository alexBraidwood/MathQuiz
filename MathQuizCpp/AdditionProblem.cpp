#include "stdafx.h"
#include "AdditionProblem.h"
#include "Quiz.h"
#include <boost/array.hpp>
#include <sstream>

using namespace std;

AdditionProblem::AdditionProblem(vector<int>& numbers) {
	this->numbers = numbers;
}

AdditionProblem::AdditionProblem(int* numbers, int len) {
	this->numbers.assign(numbers, numbers + len);
}

LPCWSTR AdditionProblem::getEquation() {
	wstringstream ss;
	unsigned int i = 0;
	for(auto x : this->numbers)
	{
		++i;

		if (i >= this->numbers.size())
		{
			ss << x;
		}
		else
		{
			ss << x << " + ";
		}
	}

	LPCWSTR str = ss.str().c_str();

	return str;
}

bool AdditionProblem::isSolution(float answer) {
	return false;
}

vector<int> AdditionProblem::getNumbers() {
	return this->numbers;
}

