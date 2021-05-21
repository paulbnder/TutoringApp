import React, { useEffect } from 'react';
import {
  Pressable, View, Image, StyleSheet, LayoutAnimation,
} from 'react-native';
import Animated, {
  withTiming, interpolate, Extrapolate,
  useDerivedValue, useAnimatedStyle, useSharedValue,
} from 'react-native-reanimated';
import { useTheme, useNavigation } from '@react-navigation/native';
import { SharedElement } from 'react-navigation-shared-element';
import * as Haptics from 'expo-haptics';

import Text from './Text';

function Teacher({ teacher, scrollX, index }) {
  const navigation = useNavigation();
  const { margin, normalize } = useTheme();
  const TEACHERWIDTH = normalize(130, 160);
  const TEACHERHEIGHT = TEACHERWIDTH * 1.5;
  const position = useDerivedValue(() => (index + 0.00001) * (TEACHERWIDTH + margin) - scrollX.value);
  const inputRange = [-TEACHERWIDTH, 0, TEACHERWIDTH, TEACHERWIDTH * 3];
  const loaded = useSharedValue(0);

  useEffect(() => {
    LayoutAnimation.easeInEaseOut();
    loaded.value = withTiming(1);
  }, []);

  const teacherDetails = () => {
    Haptics.selectionAsync();
    navigation.push('TeacherDetailsScreen', { teacher });
  };

  // Animated styles
  const anims = {
    teacher: useAnimatedStyle(() => ({
      opacity: loaded.value,
      transform: [
        { perspective: 800 },
        { scale: interpolate(position.value, inputRange, [0.9, 1, 1, 1], Extrapolate.CLAMP) },
        { rotateY: `${interpolate(position.value, inputRange, [60, 0, 0, 0], Extrapolate.CLAMP)}deg` },
        {
          translateX: scrollX.value
            ? interpolate(position.value, inputRange, [TEACHERWIDTH / 4, 0, 0, 0], 'clamp')
            : interpolate(loaded.value, [0, 1], [index * TEACHERWIDTH, 0], 'clamp'),
        },
      ],
    })),
  };

  // Styles
  const styles = StyleSheet.create({
    imgBox: {
      marginRight: margin,
      borderRadius: 10,
      shadowRadius: 3,
      shadowOpacity: 0.3,
      shadowOffset: { width: 3, height: 3 },
    },
    teacherImg: {
      width: TEACHERWIDTH,
      height: TEACHERHEIGHT,
      borderRadius: 10,
    },
    teacherText: {
      marginRight: margin,
      marginTop: margin / 2,
    },
  });

  return (
    <Pressable onPress={teacherDetails}>
      <Animated.View style={anims.teacher}>
        <SharedElement id={teacher.id}>
          <View style={styles.imgBox}>
            <Image style={styles.teacherImg} source={{ uri: teacher.profilePictureSource }} />
          </View>
        </SharedElement>
        <Text size={13} numberOfLines={1} center style={styles.teacherText}>
          {teacher.name}
        </Text>
      </Animated.View>
    </Pressable>
  );
}

export default React.memo(Teacher);