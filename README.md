# uNback 
Unity package for n-back tasks procedures based on text-based tasks described by [T. S. Braver. 1997. "A Parametric Study of Prefrontal Cortex Involvement in Human Working Memory". NeuroImage.](https://www.sciencedirect.com/science/article/pii/S1053811996902475).

![image](https://github.com/wgnrto/uNback/assets/24171719/99c7b0ba-3f9e-4a7c-8358-11c99123f0ce)


## Extensibility 
The project is structured in a way to enable the implementation of custom n-back task procedures. Just inherit from `Assets/Scripts/Task/ATask<T>` to create other types of time-dependent tasks. 

## Not implemented 
Unfortunately, the package only provides a text-based n-back task without data logging. However, integrating the logging to a CSV file shouldn't be too complicated since the reaction time is already given. 

## Disclaimer 
This project was developed during my bachelor thesis under Unity v2019. Currently, the project isn't maintained, but feel free to use it as a template or example for your own implementation of the n-back task. There's no guarantee that the package works with newer Unity versions. The last time I imported the packages, I used Unity v2022.3.3f1.

## Publications 
To the best of my knowledge, the package was used in the following publications:
- [M. Lanzer. 2023. "Interaction Effects of Pedestrian Behavior, Smartphone Distraction and External Communication of Automated Vehicles on Crossing and Gaze Behavior". CHI'23. DOI: 10.1145/3544548.3581303](https://dl.acm.org/doi/full/10.1145/3544548.3581303)
