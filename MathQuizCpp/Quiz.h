#pragma once
#include <string>

class IQuiz
{
public:
	virtual ~IQuiz() {}
	virtual int* getNumbers() = 0;
	virtual LPCWSTR getEquation() = 0;
	virtual bool isSolution(float) = 0;
};

