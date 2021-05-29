import { createStackNavigator } from '@react-navigation/stack';
import React from 'react';
import { createSharedElementStackNavigator } from 'react-navigation-shared-element';
import SignUpScreen from '../screens/SignUpScreen';
import TeacherDetailsScreen from '../screens/TeacherDetailsScreen';
import TeachersScreen from '../screens/TeachersScreen';

function StackNavigator(props) {
    const TutoringAppStack = createStackNavigator();
  return (
  <TutoringAppStack.Navigator
    initialRouteName="List"
    screenOptions={{
      headerShown: true,

    }}
  >
    <TutoringAppStack.Screen  name="TeachersScreen" component={TeachersScreen}/>
    <TutoringAppStack.Screen  name="TeacherDetailsScreen" component={TeacherDetailsScreen}/>
    <TutoringAppStack.Screen  name="SignUpScreen" component={SignUpScreen}/>

  </TutoringAppStack.Navigator>
  );
}

export default StackNavigator;