import React from 'react';
import { StyleSheet } from 'react-native';
import TeachersScreen from './app/screens/TeachersScreen';
import { createSharedElementStackNavigator } from 'react-navigation-shared-element';
import { NavigationContainer } from '@react-navigation/native';
import getTheme from './app/theme';
import { AppearanceProvider, useColorScheme } from 'react-native-appearance';
import TeacherDetailsScreen from './app/screens/TeacherDetailsScreen'




export default function App() {
  const TutoringAppStack = createSharedElementStackNavigator();
  const scheme = useColorScheme();


  return (
    <NavigationContainer theme={getTheme(scheme)}>
      <TutoringAppStack.Navigator
        initialRouteName="List"
        screenOptions={{
          headerShown: false,
          cardOverlayEnabled: true,
          cardStyle: { backgroundColor: 'transparent' },
        }}
      >
        <TutoringAppStack.Screen style={styles.container} name="TeachersScreen" component={TeachersScreen}/>
        <TutoringAppStack.Screen style={styles.container} name="TeacherDetailsScreen" component={TeacherDetailsScreen}/>

      </TutoringAppStack.Navigator>
    </NavigationContainer>
  );
}

const styles = StyleSheet.create({
  container: {
    marginTop: 50,
    paddingTop: 100
  },
});
