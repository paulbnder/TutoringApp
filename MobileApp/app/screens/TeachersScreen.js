import React, { useState, useEffect } from 'react';
import { ScrollView, Text, StyleSheet, View, FlatList } from 'react-native';
import TeacherList from '../components/TeacherList'
import { useTheme } from '@react-navigation/native';
import Animated, {
    interpolate, useAnimatedStyle, useSharedValue, useAnimatedScrollHandler, useAnimatedProps,
} from 'react-native-reanimated';
import Constants from 'expo-constants';



function TeachersScreen({ navigation }) {
    const [isLoading, setLoading] = useState(true);
    const [data, setData] = useState([]);
    const scrollY = useSharedValue(0);
 

    const scrollHandler = useAnimatedScrollHandler({
      onScroll: ({ contentOffset }) => {
        scrollY.value = contentOffset.y;
      },
    });

    useEffect(() => {
        fetch('http://10.0.2.2:5000/api/teacher', {
            method: 'GET'
          })
          .then((response) => response.json())
          .then((json) => setData(json))
          .catch((error) => console.error(error))
          .finally(() => setLoading(false));
      }, []);

    return (
      <ScrollView style={styles.container}>
        <Text>Find teachers for your subject</Text>
        <Animated.ScrollView
        scrollEventThrottle={8}
        onScroll={scrollHandler}
            >
          <TeacherList teachers={data.filter(t => t.subjects.includes("Maths"))} title="Mats" navigation={navigation} />
        </Animated.ScrollView>
        <Animated.ScrollView
        scrollEventThrottle={8}
        onScroll={scrollHandler}
            >
          <TeacherList teachers={data.filter(t => t.subjects.includes("English"))} title="English" navigation={navigation} />
        </Animated.ScrollView>
        <Animated.ScrollView
        scrollEventThrottle={8}
        onScroll={scrollHandler}
            >
          <TeacherList teachers={data.filter(t => t.subjects.includes("Spanish"))} title="Spanish" navigation={navigation} />
        </Animated.ScrollView>
        <Animated.ScrollView
        scrollEventThrottle={8}
        onScroll={scrollHandler}
            >
          <TeacherList teachers={data.filter(t => t.subjects.includes("Physics"))} title="Physics" navigation={navigation} />
        </Animated.ScrollView>
      </ScrollView>
    );
}

const status = Constants.statusBarHeight;
const styles = StyleSheet.create({
  container: {
    marginTop: status
  },
})

export default TeachersScreen;