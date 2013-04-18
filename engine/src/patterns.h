#pragma once
template <class T>
class Singleton{
    private:
        static T instance;
    public:
        static T& get_instance(){
           return instance; 
        } 

};
