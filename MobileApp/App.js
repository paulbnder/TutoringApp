import React from 'react';
import { StyleSheet } from 'react-native';
import { NavigationContainer } from '@react-navigation/native';
import getTheme from './app/theme';
import { AppearanceProvider, useColorScheme } from 'react-native-appearance';
import { createMaterialBottomTabNavigator } from '@react-navigation/material-bottom-tabs';
import StackNavigator from './app/components/StackNavigator';
import SignUpScreen from './app/screens/SignUpScreen';
import Icon from 'react-native-vector-icons/Ionicons';





export default function App() {
  const scheme = useColorScheme();
  const Tab = createMaterialBottomTabNavigator();


  return (
    <NavigationContainer theme={getTheme(scheme)}>
     <Tab.Navigator screenOptions={({ route }) => ({
          tabBarIcon: ({  }) => {
            return <Icon name="ios-person" size={20} color="white" />;
          },
        })}
        tabBarOptions={{
          activeTintColor: 'tomato',
          inactiveTintColor: 'gray',
        }}>
        <Tab.Screen name="Teachers" component={StackNavigator} />
        <Tab.Screen name="SignUp" component={SignUpScreen} />

      </Tab.Navigator>
    </NavigationContainer>
  );
}

const styles = StyleSheet.create({
  container: {
    marginTop: 50,
    paddingTop: 100
  },
});
