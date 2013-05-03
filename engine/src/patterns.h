#pragma once
template <class T>
class Singleton{
    public:
        static T& get_instance(){
            static T instance;
            return instance; 
        } 

};
